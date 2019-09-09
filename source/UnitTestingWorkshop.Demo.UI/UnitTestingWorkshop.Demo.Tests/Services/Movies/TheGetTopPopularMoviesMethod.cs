using System;
using System.Linq;
using Xunit;
using Moq;
using UnitTestingWorkshop.Demo.Services.Movies;

namespace UnitTestingWorkshop.Demo.Tests.Services.Movies
{
    public partial class MovieServiceTests
    {
        public class TheGetTopPopularMoviesMethod
        {
            [Fact]
            public void ShouldGetTopPopularMovies()
            {
                var mockMovieDataService = new Mock<IMovieDataService>();
                mockMovieDataService.Setup(s => s.LoadMovies())
                    .Returns(CreateTestMovieCollection());

                var movieService = new MovieService(mockMovieDataService.Object);

                var movies = movieService.GetTopPopularMovies(3);

                Assert.Equal(3, movies.Count());
                Assert.True(movies.First().Popularity == movies.Max(m => m.Popularity)); //The movie sorted first should have the highest popularity 
            }
        }
    }
}