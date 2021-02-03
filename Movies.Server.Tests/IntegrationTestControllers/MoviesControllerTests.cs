using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movies.Server.Tests.IntegrationTestController
{
    public class MoviesControllerTests : IClassFixture<WebApplicationFactory<Movies.API.Startup>>
    {
        private readonly HttpClient _httpClient;

        public MoviesControllerTests(WebApplicationFactory<Movies.API.Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient(new Uri("http://localhost/movies"));

        }

        [Fact]
        public async Task GetAllMovies_RetunsSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllMovies_RetunsExpectedMediaType()
        {
            var response = await _httpClient.GetAsync("");

            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
            
        }

        [Fact]
        public async Task GetAllMovies_RetunsContent()
        {
            var response = await _httpClient.GetAsync("");

            Assert.NotNull(response.Content);
            Assert.True(response.Content.Headers.ContentLength > 0);

        }

        [Fact]
        public async Task GetAllMovies_RetunsExpectedJson()
        {
            var response = await _httpClient.GetStringAsync("");

            Assert.NotNull(response);

        }

        [Fact]
        public async Task GetMovieById_RetunsExpectedMovie()
        {
            int id = 1;

            var response = await _httpClient.GetJsonAsync<Data.MoviesDto>($"movies/{id}");

            Assert.Equal(id, response.Id);

        }

        [Fact]
        public async Task GetMovieByName_RetunsExpectedMovie()
        {
            string name = "Star";

            var data = await _httpClient.GetJsonAsync<List<Movies.API.Movies>>($"movies/{name}");

            Assert.NotNull(data);

            Assert.Contains("Star", data[0].Name);

        }

        [Fact]
        public async Task DeleteMovie_NotExistMovie_RetunsNotFound()
        {
            int id = 0;

            var response = await _httpClient.DeleteAsync($"movies/{id}");
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);

        }

        //[Fact]
        //public async Task UpdateMovie_NotExistMovie_RetunsNotFound()
        //{
        //    Movies.API.Movies movie = null;

        //    await _httpClient.PutJsonAsync("", movie);
        //    //response.
        //    //Assert.True(response.StatusCode == HttpStatusCode.NotFound);

        //}

    }
}
