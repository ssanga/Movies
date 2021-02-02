using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.API;
using Movies.API.Services;
using System;
using System.Threading.Tasks;

namespace Movies.Server.Tests
{
    // https://github.com/egil/bUnit
    // https://bunit.egilhansen.com/docs/getting-started/writing-csharp-tests.html?tabs=xunit

    [TestClass]
    public class MoviesServiceTests
    {
        private IMoviesService _sut;
        private static AppDbContext _appDbContext;

        private static Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context;

        [ClassInitialize]
        public static void InitTestSuite(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            context = testContext;

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseInMemoryDatabase(databaseName: myDatabaseName)
                            .Options;

            _appDbContext = new AppDbContext(options);
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 1, Name = "Test 1", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 2, Name = "Test 2", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 3, Name = "Test 3", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 4, Name = "Test 4", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 5, Name = "Test 5", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 6, Name = "Test 6", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 7, Name = "Test 7", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 8, Name = "Test 8", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 9, Name = "Test 9", PortraitUrl = "none", Year = 2000 });
            _appDbContext.Movies.Add(new Movies.API.Movies { Id = 10, Name = "Test 10", PortraitUrl = "none", Year = 2000 });
            _appDbContext.SaveChanges();
        }

        [ClassCleanup()]
        public static void CleanupTestSuite()
        {
            _appDbContext.Dispose();
        }

        [TestInitialize]
        public void Initial()
        {
            _sut = new MoviesService(_appDbContext);
        }

        [TestMethod]
        public async Task GetMoviesAsync_Should_Return_Elements()
        {
            var data = await _sut.GetMoviesAsync();

            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        public async Task GetMoviesAsync_With_Name_Should_Return_One_Element()
        {
            string name = "Test 2";

            var data = await _sut.GetMoviesAsync(name);

            Assert.IsTrue(data.Count == 1);
        }

        [TestMethod]
        public async Task GetMovieAsync_With_Id_Should_Return_One_Element()
        {
            int id = 9;
            var data = await _sut.GetMovieAsync(id);

            Assert.IsTrue(data != null);
        }

        [TestMethod]
        public async Task CreateMovieAsync_Should_Return_New_Movie_With_New_Id()
        {
            Movies.API.Movies movie = new Movies.API.Movies { Id = 0, Name = "New Movie", PortraitUrl = "none", Year = 2000 };

            var data = await _sut.CreateMovieAsync(movie);

            Assert.IsTrue(data.Id == 11);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task CreateMovieAsync_ArgumentNullException()
        {
            Movies.API.Movies movie = null;

            var data = await _sut.CreateMovieAsync(movie);
        }

        [TestMethod]
        public async Task UpdateMovieAsync_Exisiting_Movie_Should_Return_True()
        {
            Movies.API.Movies movie = new Movies.API.Movies { Id = 9, Name = "New Movie", PortraitUrl = "none", Year = 2021 };

            var result = await _sut.UpdateMovieAsync(movie);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateMovieAsync_Missing_Movie_Should_Return_False()
        {
            Movies.API.Movies movie = new Movies.API.Movies { Id = 999, Name = "Does not Exist", PortraitUrl = "none", Year = 2021 };

            var result = await _sut.UpdateMovieAsync(movie);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateMovieAsync_ArgumentNullException()
        {
            Movies.API.Movies movie = null;

            var data = await _sut.UpdateMovieAsync(movie);
        }

        [TestMethod]
        public async Task DeleteMovieAsync_Exisiting_Movie_Should_Return_True()
        {
            int id = 1;
            var result = await _sut.DeleteMovieAsync(id);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteMovieAsync_Missing_Movie_Should_Return_False()
        {
            int id = 999;
            var result = await _sut.DeleteMovieAsync(id);
            Assert.IsFalse(result);
        }
    }
}