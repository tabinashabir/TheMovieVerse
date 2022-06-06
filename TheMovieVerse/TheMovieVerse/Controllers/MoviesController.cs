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
using TheMovieVerse.Services.Interface;
using TheMovieVerse.ViewModel;

namespace TheMovieVerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MoviesController(MovieDbContext context, IMapper mapper, IMovieService movieService)
        {
            _context = context;
            this._mapper = mapper;
            this._movieService = movieService;
        }


        // GET: api/Get All Movies
        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<List<MovieView>>> GetMovies()
        {

            return await _movieService.GetAll();
            
        }

        // GET: api/Movies/MoviesLanguage
        [HttpGet("GetMovieByLanguage/{MovieLanguage}")]
        public async Task<ActionResult<List<MovieTitleView>>> GetMovieByLanguage(string MovieLanguage)
        {
            return await _movieService.GetMovieByLanguage(MovieLanguage);
        }

        [HttpGet("GetMovieByGenre/{MovieGenre}")]
        public async Task<ActionResult<List<Movie>>> GetMovieByGenre(string MovieGenre)
        {
            return await _movieService.GetMovieByGenre(MovieGenre);
        }

        [HttpGet("GetMovieByName/{MovieTitle}")]
        public async Task<ActionResult<Movie>> GetMovieByName(string MovieTitle)
        {
            return await _movieService.GetMovieByName(MovieTitle);
        }

        // GET: api/Movies/5
        [HttpGet("GetMovieById{id}")]
        public async Task<ActionResult<Movie>> GetMovie(long id)
        {
            return await _movieService.GetMovieById(id);

        }
        
        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("UpdateMovieUsingId{id}")]
        public async Task<long> PutMovie(EditMovieView movie)
        {
            long mid = await _movieService.PutMovie(movie);
            return mid;
        }

        // POST: api/Movies
        [HttpPost("AddMovies")]
        public async Task<ActionResult<long>> PostMovie(MovieView movie)
        {
            try
            {
                long id =await _movieService.PostMovie(movie);
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("DeleteAMovie{id}")]
        public async Task<ActionResult<long>> DeleteMovie(long id)
        {
            long newid = await _movieService.DeleteMovie(id);
            return newid;
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
