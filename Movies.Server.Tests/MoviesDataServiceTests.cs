//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Moq.Contrib.HttpClient;
//using Movies.API;
//using Movies.API.Services;
//using Newtonsoft.Json;
//using System;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace Movies.Server.Tests
//{
//    //https://dejanstojanovic.net/aspnet/2020/march/mocking-httpclient-in-unit-tests-with-moq-and-xunit/
//    //https://kagamine.dev/en/mock-httpclient-the-easy-way/
//    //https://github.com/maxkagamine/Moq.Contrib.HttpClient

//    [TestClass]
//    public class MoviesDataServiceTests
//    {
//        private IMoviesService _sut;
//        private static AppDbContext _appDbContext;

//        private static Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context;
//        private object BaseUrl;

//        [ClassInitialize]
//        public static void InitTestSuite(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
//        {
//            context = testContext;

            
//        }

//        [ClassCleanup()]
//        public static void CleanupTestSuite()
//        {
            
//        }

//        [TestInitialize]
//        public void Initial()
//        {
            
            
//        }

//        [TestMethod]
//        public async Task GetMoviesAsync_Should_Return_Elements()
//        {
//            BaseUrl = "http://localhost:9090";

//            var handler = new Mock<HttpMessageHandler>();
//            var client = handler.CreateClient();

//            // A simple example that returns 404 for any request
//            handler.SetupAnyRequest()
//                .ReturnsResponse(HttpStatusCode.NotFound);

//            // Match GET requests to an endpoint that returns json (defaults to 200 OK)
//            handler.SetupRequest(HttpMethod.Get, "https://example.com/api/stuff")
//                .ReturnsResponse(JsonConvert.SerializeObject(model), "application/json");


//            // Verify methods are provided matching the setup helpers
//            handler.VerifyAnyRequest(Times.Exactly(3));

//            var data = await _sut.GetMoviesAsync();

//            Assert.IsTrue(data.Count > 0);
//        }

//        //[TestMethod]
//        //public async Task GetMoviesAsync_With_Name_Should_Return_One_Element()
//        //{
//        //    string name = "Test 2";

//        //    var data = await _sut.GetMoviesAsync(name);

//        //    Assert.IsTrue(data.Count == 1);
//        //}

//        //[TestMethod]
//        //public async Task GetMovieAsync_With_Id_Should_Return_One_Element()
//        //{
//        //    int id = 9;
//        //    var data = await _sut.GetMovieAsync(id);

//        //    Assert.IsTrue(data != null);
//        //}

//        //[TestMethod]
//        //public async Task CreateMovieAsync_Should_Return_New_Movie_With_New_Id()
//        //{
//        //    Movies.API.Movies movie = new Movies.API.Movies { Id = 0, Name = "New Movie", PortraitUrl = "none", Year = 2000 };

//        //    var data = await _sut.CreateMovieAsync(movie);

//        //    Assert.IsTrue(data.Id == 11);
//        //}

//        //[TestMethod]
//        //[ExpectedException(typeof(ArgumentNullException))]
//        //public async Task CreateMovieAsync_ArgumentNullException()
//        //{
//        //    Movies.API.Movies movie = null;

//        //    var data = await _sut.CreateMovieAsync(movie);
//        //}

//        //[TestMethod]
//        //public async Task UpdateMovieAsync_Exisiting_Movie_Should_Return_True()
//        //{
//        //    Movies.API.Movies movie = new Movies.API.Movies { Id = 9, Name = "New Movie", PortraitUrl = "none", Year = 2021 };

//        //    var result = await _sut.UpdateMovieAsync(movie);

//        //    Assert.IsTrue(result);
//        //}

//        //[TestMethod]
//        //public async Task UpdateMovieAsync_Missing_Movie_Should_Return_False()
//        //{
//        //    Movies.API.Movies movie = new Movies.API.Movies { Id = 999, Name = "Does not Exist", PortraitUrl = "none", Year = 2021 };

//        //    var result = await _sut.UpdateMovieAsync(movie);

//        //    Assert.IsFalse(result);
//        //}

//        //[TestMethod]
//        //[ExpectedException(typeof(ArgumentNullException))]
//        //public async Task UpdateMovieAsync_ArgumentNullException()
//        //{
//        //    Movies.API.Movies movie = null;

//        //    var data = await _sut.UpdateMovieAsync(movie);
//        //}

//        //[TestMethod]
//        //public async Task DeleteMovieAsync_Exisiting_Movie_Should_Return_True()
//        //{
//        //    int id = 1;
//        //    var result = await _sut.DeleteMovieAsync(id);
//        //    Assert.IsTrue(result);
//        //}

//        //[TestMethod]
//        //public async Task DeleteMovieAsync_Missing_Movie_Should_Return_False()
//        //{
//        //    int id = 999;
//        //    var result = await _sut.DeleteMovieAsync(id);
//        //    Assert.IsFalse(result);
//        //}
//    }
//}