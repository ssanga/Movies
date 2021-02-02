using Bunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Server.Components;
using Movies.Server.Data;

namespace Movies.Server.Tests.BlazorComponents
{
    // https://github.com/egil/bUnit
    // https://bunit.egilhansen.com/docs/getting-started/writing-csharp-tests.html?tabs=xunit
    // https://bunit.egilhansen.com/docs/providing-input/passing-parameters-to-components.html?tabs=csharp

    [TestClass]
    public class MsgBoxBlazorTest : Bunit.TestContext
    {
        private readonly Bunit.TestContext _ctx;

        public MsgBoxBlazorTest()
        {
            _ctx = new Bunit.TestContext();
            //_ctx.Services.AddSingleton<ITimeCalculation>(new TimeCalculation());
        }

        [TestMethod]
        public void MsgBoxBlazor_Renders_Correctly()
        {
            //Arrange
            string message = "This is a test message";

            // Act
            var cut = _ctx.RenderComponent<MsgBoxBlazor>(parameters: ("Message", message));
            var content = cut.Markup;

            // Assert
            Assert.IsTrue(content.Contains(message));
        }

        //[TestMethod]
        //public void MovieView_Renders_IsButtonActionsVisible_True()
        //{
        //    MoviesDto movie = new MoviesDto
        //    {
        //        Id = 1,
        //        Name = "Movie Name Test",
        //        PortraitUrl = "Portrait Test",
        //        Year = 2000
        //    };

        //    // Act
        //    var cut = _ctx.RenderComponent<MovieView>(
        //        ("Movie", movie), 
        //        ("IsButtonActionsVisible", true));

        //    var button = cut.Find("button");

        //    // Assert
        //    Assert.IsNotNull(button);
        //}

        //[TestMethod]
        //public void MovieView_Renders_IsButtonActionsVisible_False()
        //{
        //    MoviesDto movie = new MoviesDto
        //    {
        //        Id = 1,
        //        Name = "Movie Name Test",
        //        PortraitUrl = "Portrait Test",
        //        Year = 2000
        //    };

        //    // Act
        //    var cut = _ctx.RenderComponent<MovieView>(
        //        ("Movie", movie),
        //        ("IsButtonActionsVisible", false));

        //    //var button = cut.Find("button");
        //    var content = cut.Markup;

        //    // Assert
        //    Assert.IsFalse(content.Contains("button"));
        //}


    }
}