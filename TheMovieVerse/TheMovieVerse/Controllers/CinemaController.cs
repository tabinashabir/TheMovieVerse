using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMovieVerse.DB;
using TheMovieVerse.Model;

namespace TheMovieVerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public CinemaController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cinema>>> GetCinemas()
        {
            return await _context.Cinemas
                .Include(x=>x.Theatres)
                .ToListAsync();
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> GetCinema(long id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);

            if (cinema == null)
            {
                return NotFound();
            }

            return cinema;
        }

        // PUT: api/Cinemas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinema(long id, Cinema cinema)
        {
            if (id != cinema.Id)
            {
                return BadRequest();
            }

            _context.Entry(cinema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cinemas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cinema>> PostCinema(Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCinema", new { id = cinema.Id }, cinema);
        }

        // DELETE: api/Cinemas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cinema>> DeleteCinema(long id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();

            return cinema;
        }

        private bool CinemaExists(long id)
        {
            return _context.Cinemas.Any(e => e.Id == id);
        }
    }
}
