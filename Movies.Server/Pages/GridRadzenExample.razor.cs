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
    public partial class GridRadzenExample
    {
        [Inject]
        protected IMoviesDataService _moviesDataService { get; set; }

        [Inject]
        protected ILogger<GridRadzenExample> _logger { get; set; }

        [Inject]
        protected IToastService _toastService { get; set; }

        [CascadingParameter] public IModalService Modal { get; set; }

        RadzenGrid<MoviesDto> grid;

        public List<MoviesDto> movies;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                movies = await _moviesDataService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                //await ShowNotificationError("OnInitializedAsync", ex.Message);
            }

        }

        public async void ShowModalNewMovie()
        {
            var parameters = new ModalParameters();

            // I build a new blank movie
            var newMovie = new MoviesDto { Year = DateTime.Today.Year };
            // Add as modal screen parameter
            parameters.Add("Movie", newMovie);

            var formModal = Modal.Show<MoviesModal>("Create Movie", parameters);
            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                var data = (MoviesDto)result.Data;
                //AddToOrder(item);

                // Insert data (local list collection and DB)
                var insertedMovie = await _moviesDataService.Add(newMovie);
                movies.Add(insertedMovie);
                await grid.Reload();
                StateHasChanged();

                _toastService.ShowSuccess($"{newMovie.Name} added!");
            }

        }

        async void UpdateMovie(MoviesDto movie)
        {
            var parameters = new ModalParameters();

            // I Clone updatable movie
            var updateMovie = (MoviesDto)movie.Clone();
            // Add as modal screen parameter
            parameters.Add("Movie", updateMovie);

            var formModal = Modal.Show<MoviesModal>("Update Movie", parameters);
            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                var data = (MoviesDto)result.Data;
                //AddToOrder(item);

                // Update data (local list collection and DB)
                await _moviesDataService.Update(updateMovie);
                /// ToDo: Do by reflection
                movie.Name = updateMovie.Name;
                movie.Year = updateMovie.Year;
                movie.PortraitUrl = updateMovie.PortraitUrl;

                await grid.Reload();
                StateHasChanged();
            }
        }


        async void RemoveMovie(MoviesDto movie)
        {
            var parameters = new ModalParameters();

            parameters.Add("Title", "Delete Movie");
            parameters.Add("Message", $"Do you want delete {movie.Name}?");

            var formModal = Modal.Show<MsgBoxBlazor>("Delete Movie", parameters);
            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                movies.Remove(movie);
                await _moviesDataService.Delete(movie.Id);
                await grid.Reload();
                StateHasChanged();
            }

        }
    }
}
