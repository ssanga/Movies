using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.API.Services
{
    public interface IMoviesService
    {
        Task<Movies> CreateMovieAsync(Movies movie);
        Task<bool> DeleteMovieAsync(int id);
        Task<List<Movies>> GetMoviesAsync();
        Task<List<Movies>> GetMoviesAsync(string name);
        Task<Movies> GetMovieAsync(int id);
        Task<bool> UpdateMovieAsync(Movies movie);
    }
}