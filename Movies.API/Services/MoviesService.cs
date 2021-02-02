using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movies>> GetMoviesAsync()
        {
            return await _context.Movies.AsNoTracking().OrderByDescending(n => n.Id).ToListAsync();
        }

        public async Task<List<Movies>> GetMoviesAsync(string name)
        {
            return await _context.Movies
                        .AsNoTracking()
                        .Where(n=>n.Name.StartsWith(name))
                        .OrderByDescending(n => n.Name)
                        .ToListAsync();
        }

        public async Task<Movies> GetMovieAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Movies> CreateMovieAsync(Movies movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie), "Movie cannot be null");
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> UpdateMovieAsync(Movies movie)
        {

            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie), "Movie cannot be null");
            }

            var row = await GetMovieAsync(movie.Id);

            if (row != null)
            {
                row.Name = movie.Name;
                row.Year = movie.Year;
                row.PortraitUrl = movie.PortraitUrl;

                _context.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {

            var row = await GetMovieAsync(id);

            if (row != null)
            {
                _context.Movies.Remove(row);
                await _context.SaveChangesAsync();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
