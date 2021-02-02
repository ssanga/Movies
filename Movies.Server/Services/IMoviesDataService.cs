using Movies.Server.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Server.Services
{
    public interface IMoviesDataService
    {
        Task<MoviesDto> Add(MoviesDto movie);
        Task Delete(int id);
        Task<List<MoviesDto>> GetAll();
        Task<List<MoviesDto>> GetByNameAsync(string name);
        Task<MoviesDto> GetByIdAsync(int id);
        MoviesDto GetById(int id);
        Task Update(MoviesDto movie);
    }
}