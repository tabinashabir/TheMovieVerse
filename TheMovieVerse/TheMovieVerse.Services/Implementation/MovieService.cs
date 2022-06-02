using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using TheMovieVerse.DB.Interface;
using TheMovieVerse.Model;
using TheMovieVerse.Services.Interface;
using TheMovieVerse.ViewModel;
using System.Threading.Tasks;
using TheMovieVerse.DB;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TheMovieVerse.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _movieDbContext;
        private readonly IMapper _mapper;

        public MovieService(MovieDbContext movieDbContext, IMapper mapper)
        {
            this._movieDbContext = movieDbContext;
            this._mapper = mapper;
        }
        public async Task<long> DeleteMovie(long id)
        {
            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Include(x => x.ShowSchedules)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                return id;
            }

            _movieDbContext.Movies.Remove(movie);
            await _movieDbContext.SaveChangesAsync();

            return id;
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Include(x => x.ShowSchedules)
                .ToListAsync();
        }
        public async Task<List<Movie>> GetMovieByLanguage(string MovieLanguage)
        {
            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Include(x => x.ShowSchedules)
                .Where(x => x.MovieLanguage == MovieLanguage)
                .ToListAsync();
            return movie;
        }
        public async Task<List<Movie>> GetMovieByGenre(string MovieGenre)
        {
            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Include(x => x.ShowSchedules)
                .Where(x => x.MovieGenre == MovieGenre)
                .ToListAsync();
            return movie;
        }
        public async Task<Movie> GetMovieByName(string MovieTitle){

            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Include(x => x.ShowSchedules)
                .Where(x => x.MovieTitle == MovieTitle)
                .FirstOrDefaultAsync();
            return movie;

        }






        public async Task<Movie> GetMovieById(long movieId)
        {
            var movie = await _movieDbContext.Movies
                .Include(x => x.Actors)
                .Include(x => x.ShowSchedules)
                .Where(x=>x.Id==movieId)
                .FirstOrDefaultAsync();

            
            return movie;
        }

        public async Task<long> PostMovie(MovieView movie)
        {
            try
            {
                var movieModel = _mapper.Map<Movie>(movie);
                _movieDbContext.Movies.Add(movieModel);
                await _movieDbContext.SaveChangesAsync();
                return movieModel.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //public async Task<long> PutMovie(long id, Movie movie)
        //{
        //    //if (id != movie.Id)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    _movieDbContext.Entry(movie).State = EntityState.Modified;

        //    try
        //    {
        //        return await _movieDbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MovieExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    //return await _movieDbContext.SaveChangesAsync();

        //    return NoContent();
        //}

        public async Task<long> PutMovie(long id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            _movieDbContext.Entry(movie).State = EntityState.Modified;
            try
            {
                await _movieDbContext.SaveChangesAsync();
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

        private bool MovieExists(long id)
        {
            return _movieDbContext.Movies.Any(e => e.Id == id);
        }

        private long NoContent()
        {
            throw new NotImplementedException();
        }

        private long NotFound()
        {
            throw new NotImplementedException();
        }

        private long BadRequest()
        {
            throw new NotImplementedException();
        }
    }
}
