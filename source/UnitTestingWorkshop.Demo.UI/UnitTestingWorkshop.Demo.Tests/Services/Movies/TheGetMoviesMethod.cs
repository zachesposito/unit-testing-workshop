using System;
using System.Linq;
using Xunit;
using Moq;
using UnitTestingWorkshop.Demo.Services.Movies;

namespace UnitTestingWorkshop.Demo.Tests.Services.Movies
{
    public partial class MovieServiceTests
    {
        public class TheGetMoviesMethod
        {
            [Fact]
            public void ShouldGetMovies()
            {
                var mockMovieDataService = new Mock<IMovieDataService>();
                mockMovieDataService.Setup(s => s.LoadMovies())
                    .Returns(CreateTestMovieCollection());

                var movieService = new MovieService(mockMovieDataService.Object);

                var movies = movieService.GetMovies();

                Assert.Equal(5, movies.Count());
            }
        }
    }
}