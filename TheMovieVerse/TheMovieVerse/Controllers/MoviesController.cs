using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMovieVerse.DB;
using TheMovieVerse.Model;
using TheMovieVerse.ViewModel;

namespace TheMovieVerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }


        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            
            return await _context.Movies
                .Include(x=>x.Actors)
                .Include(x=>x.ShowSchedules)
                .ToListAsync();

        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            //var Shows = await _context.ShowSchedules.FindAsync(id);
            //var movie = (Fro)

            if (movie == null)
            {
                return NotFound();
            }
            return movie;

        }
        
        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(long id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieView>> PostMovie(MovieView movie)
        {
            try
            {
                var movieModel = _mapper.Map<Movie>(movie);
                _context.Movies.Add(movieModel);
                await _context.SaveChangesAsync();
                //return CreatedAtAction("GetMovie", new { name = movie.MovieTitle }, movie);
                
                return StatusCode(StatusCodes.Status201Created, $"A new movie is saved with");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error occurred while saving a movie");
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
