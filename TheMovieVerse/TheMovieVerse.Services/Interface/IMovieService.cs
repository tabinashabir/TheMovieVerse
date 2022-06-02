using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovieVerse.Model;
using TheMovieVerse.ViewModel;

namespace TheMovieVerse.Services.Interface
{
    public interface IMovieService
    {
        public Task<Movie> GetMovieById(long movieId);
        public Task<List<Movie>> GetAll();
        public Task<List<Movie>> GetMovieByLanguage(string MovieLanguage);
        public Task<List<Movie>> GetMovieByGenre(string MovieGenre);
        public Task<Movie> GetMovieByName(string MovieTitle);
        

        public Task<long> PostMovie (MovieView movie);
        public Task<long> PutMovie(long id,Movie movie);
        public Task<long> DeleteMovie(long id);   
    }
}
