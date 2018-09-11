using System.Collections.Generic;
using UnitTestingWorkshop.Demo.Services.Movies.Models;

namespace UnitTestingWorkshop.Demo.Services.Movies
{
    public interface IMovieDataService
    {
        IEnumerable<Movie> LoadMovies();
    }
}