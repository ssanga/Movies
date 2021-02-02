//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace Movies.API.Tests
//{
//    [TestClass]
//    public class MoviesControllerIntegrationTests : WebApplicationFactory<Startup>
//    {
//        private readonly HttpClient _httpClient;
//        private readonly WebApplicationFactory<Startup> _factory;

//        public MoviesControllerIntegrationTests(WebApplicationFactory<Startup> factory)
//        {
//            //factory.ClientOptions.BaseAddress = new Uri("http://localhost/movies/");
//            //_client = factory.CreateClient();
//            //_factory = factory;

//            _httpClient = factory.CreateDefaultClient();
//        }

//        [TestMethod]
//        public async Task GetAll_ReturnsOk()
//        {
//            var response = await _httpClient.GetAsync("/movies");

//            Assert.Equals(HttpStatusCode.OK, response.StatusCode);
//        }
//    }
//}
