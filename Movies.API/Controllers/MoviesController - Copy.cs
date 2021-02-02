//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Movies.API.Services;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Movies.API.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class MoviesController : ControllerBase
//    {
//        private readonly ILogger<MoviesController> _logger;
//        private readonly IMoviesService _moviesService;

//        public MoviesController(IMoviesService moviesService, ILogger<MoviesController> logger)
//        {
//            _moviesService = moviesService ?? throw new ArgumentNullException(nameof(moviesService));
//            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//        }

//        //[HttpGet(Name = "GetAllMovies")]
//        //[HttpHead]
//        //public ActionResult<IEnumerable<Movies>> GetAuthors(
//        //    [FromQuery] MoviesResourceParameters moviesResourceParameters)
//        //{
//        //    var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);

//        //    var previousPageLink = authorsFromRepo.HasPrevious ?
//        //        CreateAuthorsResourceUri(authorsResourceParameters,
//        //        ResourceUriType.PreviousPage) : null;

//        //    var nextPageLink = authorsFromRepo.HasNext ?
//        //        CreateAuthorsResourceUri(authorsResourceParameters,
//        //        ResourceUriType.NextPage) : null;

//        //    var paginationMetadata = new
//        //    {
//        //        totalCount = authorsFromRepo.TotalCount,
//        //        pageSize = authorsFromRepo.PageSize,
//        //        currentPage = authorsFromRepo.CurrentPage,
//        //        totalPages = authorsFromRepo.TotalPages,
//        //        previousPageLink,
//        //        nextPageLink
//        //    };

//        //    Response.Headers.Add("X-Pagination",
//        //        JsonSerializer.Serialize(paginationMetadata));

//        //    return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
//        //}

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Movies>>> Get()
//        {
//            //_logger.LogInformation("Get called");
//            return Ok(await _moviesService.GetMoviesAsync());
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Movies>> Get(int id)
//        {
//            var row = await _moviesService.GetMovieAsync(id);

//            if (row == null)
//            {
//                return NotFound();
//            }

//            return Ok(row);
//        }

//        ////https://stackoverflow.com/questions/64137002/multiple-get-methods-in-net-core-3-1-web-api
//        //[HttpGet("GetByName/{name}")]
//        //public async Task<IActionResult> GetByName(string name)
//        //{
//        //    return Ok();
//        //}

//        [HttpPost]
//        public async Task<ActionResult<Movies>> Post(Movies movie)
//        {
//            await _moviesService.CreateMovieAsync(movie);
//            //return CreatedAtAction(nameof(movie), new { id = movie.Id }, movie);
//            //https://stackoverflow.com/questions/39459348/asp-net-core-web-api-no-route-matches-the-supplied-values
//            return CreatedAtAction("Post", movie);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var found = await _moviesService.DeleteMovieAsync(id);

//            if (!found)
//            {
//                return NotFound();
//            }

//            return NoContent();
//        }

//        [HttpPut()]
//        public async Task<IActionResult> Put(Movies movie)
//        {
//            if (movie == null)
//            {
//                return BadRequest();
//            }

//            var row = await _moviesService.GetMovieAsync(movie.Id);

//            if (row == null)
//            {
//                return NotFound();
//            }

//            await _moviesService.UpdateMovieAsync(movie);

//            return NoContent();
//        }
//    }
//}