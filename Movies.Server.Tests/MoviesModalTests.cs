using Bunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Server.Components;
using Movies.Server.Data;

namespace Movies.Server.Tests
{
    // https://github.com/egil/bUnit
    // https://bunit.egilhansen.com/docs/getting-started/writing-csharp-tests.html?tabs=xunit

    [TestClass]
    public class MoviesModalTests : Bunit.TestContext
    {
        private Bunit.TestContext _ctx;

        public MoviesModalTests()
        {
            _ctx = new Bunit.TestContext();
            //_ctx.Services.AddSingleton<ITimeCalculation>(new TimeCalculation());
        }

        [TestMethod]
        public void MoviesModalComponent_Renders_Correctly()
        {
            MoviesDto movie = new MoviesDto
            {
                Id = 1,
                Name = "Movie Name Test",
                PortraitUrl = "Portrait Test",
                Year = 2000
            };

            // Act
            var cut = _ctx.RenderComponent<MoviesModal>();
            cut.SetParametersAndRender(parameters => parameters.Add(p => p.Movie, movie));

            var content = cut.Markup;

            // Assert
            Assert.IsTrue(content.Contains("Movie Name Test"));
        }

        [TestMethod]
        public void MoviesModalComponent_InputMovie_NameChangeOk()
        {
            MoviesDto movie = new MoviesDto
            {
                Id = 1,
                Name = "Movie Name Test",
                PortraitUrl = "Portrait Test",
                Year = 2000
            };

            // Act
            var cut = _ctx.RenderComponent<MoviesModal>();
            cut.SetParametersAndRender(parameters => parameters.Add(p => p.Movie, movie));

            var inputMovieName = cut.Find("input");

            inputMovieName.Change("Other value");

            var content = inputMovieName.OuterHtml;

            // Assert
            Assert.IsTrue(content.Contains("Other value"));
        }

        //[Fact]
        //public void TimeCalculatorComponent_RendersCorrectly_h1()
        //{
        //    // Act
        //    var cut = _ctx.RenderComponent<TimeCalculator>();

        //    var smallElm = cut.Find("h1");

        //    // Assert
        //    smallElm.MarkupMatches("<h1>Meeting Calculator</h1>");
        //}

        //[Fact]
        //public void TimeCalculatorComponent_ClickStartButtonShouldChangeTestButtonToStop()
        //{
        //    // Act
        //    var cut = _ctx.RenderComponent<TimeCalculator>();

        //    cut.Find("button").Click();

        //    // Assert - find differences between first render and click
        //    var diffs = cut.GetChangesSinceFirstRender();

        //    // Only expect there to be one change
        //    var diff = diffs.ShouldHaveSingleChange();
        //    // and that change should be a text
        //    // change to "Stop"
        //    diff.ShouldBeTextChange("Stop");
        //}
    }
}