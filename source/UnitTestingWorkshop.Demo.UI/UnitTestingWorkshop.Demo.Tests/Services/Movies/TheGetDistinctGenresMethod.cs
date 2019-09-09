using System;
using System.Linq;
using Xunit;
using Moq;
using UnitTestingWorkshop.Demo.Services.Movies;

namespace UnitTestingWorkshop.Demo.Tests.Services.Movies
{
    public partial class MovieServiceTests
    {
        public class TheGetDistinctGenresMethod
        {
            [Fact]
            public void ShouldGetDistinctGenres()
            {
                var mockMovieDataService = new Mock<IMovieDataService>();
                mockMovieDataService.Setup(s => s.LoadMovies())
                    .Returns(CreateTestMovieCollection());

                var movieService = new MovieService(mockMovieDataService.Object);

                var distinctGenres = movieService.GetDistinctGenres();

                Assert.Equal(4, distinctGenres.Count());
                Assert.True(distinctGenres.Distinct().Count() == distinctGenres.Count()); //Check whether result is really distinct
            }
        }
    }
}