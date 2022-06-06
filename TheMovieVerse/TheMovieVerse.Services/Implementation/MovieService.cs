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
                .Include(x => x.MovieActors)
                //.Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                return id;
            }

            _movieDbContext.Movies.Remove(movie);
            await _movieDbContext.SaveChangesAsync();

            return id;
        }

        public async Task<List<MovieView>> GetAll()
        {
            var moviesModel=await _movieDbContext.Movies
                .Include(x=>x.MovieActors)
                .ToListAsync();
            foreach (var actorId in moviesModel.Select(x=>x.MovieActors).Select(y=>y.ActorId))
            {
                _movieDbContext.Actors.Where(x => x.ActorId == actorId);
            }
            

            var reqList = _mapper.Map<List<MovieView>>(moviesModel);
            return reqList;
        }


        public async Task<List<MovieTitleView>> GetMovieByLanguage(string MovieLanguage)
        {
            
            var movie = await _movieDbContext.Movies
                 
                 .Where(x => x.MovieLanguage == MovieLanguage)
                 .Select(x => new MovieTitleView { MovieTitle = x.MovieTitle})
                .ToListAsync();
            
            var rewList = _mapper.Map<List<MovieTitleView>>(movie);
            return rewList;
        }
        public async Task<List<Movie>> GetMovieByGenre(string MovieGenre)
        {
            var movie = await _movieDbContext.Movies
                //.Include(x => x.Actors)
                
                .Where(x => x.MovieGenre == MovieGenre)
                .ToListAsync();

            return movie;
        }
        public async Task<Movie> GetMovieByName(string MovieTitle){

            var movie = await _movieDbContext.Movies
                //.Include(x => x.Actors)
                
                .Where(x => x.MovieTitle == MovieTitle)
                .FirstOrDefaultAsync();
            return movie;

        }






        public async Task<Movie> GetMovieById(long movieId)
        {
            var movie = await _movieDbContext.Movies
                //.Include(x => x.Actors)
                 
                //.Where(x=>x.Id==movieId)
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
                return movieModel.MovieId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<long> PutMovie(EditMovieView movie)
        {
            var movieModel = _mapper.Map<Movie>(movie);
            _movieDbContext.Movies.Update(movieModel);
            return await _movieDbContext.SaveChangesAsync();
        }

        private bool MovieExists(long id)
        {
            return _movieDbContext.Movies.Any(e => e.MovieId == id);
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
