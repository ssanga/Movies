using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Movies.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Server.Services
{
    public class MoviesDataService : IMoviesDataService
    {
        private HttpClient _client;
        private readonly ILogger<MoviesDataService> _logger;

        public MoviesDataService(HttpClient client, ILogger<MoviesDataService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<List<MoviesDto>> GetAll()
        {
            var data = await _client.GetJsonAsync<List<MoviesDto>>("movies");

            if (data != null)
            {
                data = data.OrderBy(n => n.Id).ToList();
            }

            return data;
        }

        public async Task<List<MoviesDto>> GetByNameAsync(string name)
        {
            List<MoviesDto> data = null;

            if(string.IsNullOrEmpty(name))
            {
                data = await GetAll();
            }
            else
            {
                data = await _client.GetJsonAsync<List<MoviesDto>>($"movies/{name}");
            }

            

            if (data != null)
            {
                data = data.OrderBy(n => n.Name).ToList();
            }

            return data;
        }

        public async Task<MoviesDto> GetByIdAsync(int id)
        {
            try
            {
                var data = await _client.GetJsonAsync<MoviesDto>($"movies/{id}");

                return data;
            }
            catch (System.Exception ex)
            {
                string xxx = ex.Message;
                return null;
            }
        }

        public MoviesDto GetById(int id)
        {
            try
            {
                //var data = _client.GetJsonAsync<MoviesDto>($"movies/{id}").Result;
                var data = new MoviesDto { Id = 1, Name = "Test", PortraitUrl = "http://test.jpg", Year = 2021 };

                return null;
            }
            catch (System.Exception ex)
            {
                string xxx = ex.Message;
                return null;
            }
        }

        public async Task<MoviesDto> Add(MoviesDto movie)
        {
            return await _client.PostJsonAsync<MoviesDto>("movies", movie);
        }

        public async Task Update(MoviesDto movie)
        {
            await _client.PutJsonAsync("movies", movie);
        }

        public async Task Delete(int id)
        {
            await _client.DeleteAsync($"movies/{id}");
        }


    }
}