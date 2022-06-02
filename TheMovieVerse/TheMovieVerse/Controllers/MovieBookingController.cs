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
    public class MovieBookingController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MovieBookingController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieBooking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieBooking>>> GetMovieBookings()
        {
            return await _context.MovieBookings.ToListAsync();
        }

        // GET: api/MovieBooking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieBooking>> GetMovieBooking(long id)
        {
            var movieBooking = await _context.MovieBookings.FindAsync(id);

            if (movieBooking == null)
            {
                return NotFound();
            }

            return movieBooking;
        }

        // PUT: api/MovieBooking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieBooking(long id, MovieBooking movieBooking)
        {
            if (id != movieBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieBookingExists(id))
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

        // POST: api/MovieBooking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieBooking>> PostMovieBooking(MovieBooking movieBooking)
        {
            _context.MovieBookings.Add(movieBooking);
            //for (int i = 0; i <= movieBooking.NoOfTickets; i++)
            //{
            //   // movieBooking.Seats;
            //}

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieBooking", new { id = movieBooking.Id }, movieBooking);
        }

        // DELETE: api/MovieBooking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieBooking>> DeleteMovieBooking(long id)
        {
            var movieBooking = await _context.MovieBookings.FindAsync(id);
            if (movieBooking == null)
            {
                return NotFound();
            }

            _context.MovieBookings.Remove(movieBooking);
            await _context.SaveChangesAsync();

            return movieBooking;
        }

        private bool MovieBookingExists(long id)
        {
            return _context.MovieBookings.Any(e => e.Id == id);
        }
    }
}
