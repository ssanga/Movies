using BlazorAnimate;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Movies.Server.Components;
using Movies.Server.Data;
using Movies.Server.Services;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Pages
{
    public partial class GridBlazoriseExample
    {
        //https://www.youtube.com/watch?v=LCDmMAWqz50&t=4s
        [Inject]
        protected IMoviesDataService _moviesDataService { get; set; }

        [Inject]
        protected ILogger<GridBlazoriseExample> _logger { get; set; }


        public List<MoviesDto> movies;
        public MoviesDto selectedMovie;

        private Animate animate;

        protected override void OnInitialized()
        {
            if(animate==null)
            {
                animate = new Animate();
            }

            animate.Run();
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (animate == null)
                {
                    animate = new Animate();
                }

                movies = await _moviesDataService.GetAll();

                animate.Run();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                //await ShowNotificationError("OnInitializedAsync", ex.Message);
            }

        }

        
    }
}
