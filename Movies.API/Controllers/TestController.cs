using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesService _moviesService;

        public TestController(IMoviesService moviesService, ILogger<MoviesController> logger)
        {
            _moviesService = moviesService ?? throw new ArgumentNullException(nameof(moviesService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> Get()
        {
            return Ok(await _moviesService.GetMoviesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> Get(int id)
        {
            var row = await _moviesService.GetMovieAsync(id);

            if (row == null)
            {
                return NotFound();
            }

            return Ok(row);
        }

    }
}