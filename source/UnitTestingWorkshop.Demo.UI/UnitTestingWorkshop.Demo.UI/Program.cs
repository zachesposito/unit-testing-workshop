using System;
using System.Linq;
using UnitTestingWorkshop.Demo.Services.Movies;

namespace UnitTestingWorkshop.Demo.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var movieDataService = new MovieDataService();
            var movieService = new MovieService(movieDataService);

            Console.WriteLine($"Welcome to the Movie Service, we have { movieService.GetMovies().Count() } movies");
            Console.WriteLine("Top 5 movies by popularity:");
            foreach (var movie in movieService.GetMovies().OrderByDescending(m => m.Popularity).Take(5))
            {
                Console.WriteLine(movie.GetDescription() + Environment.NewLine);
            }

            var distinctGenres = movieService.GetGenres();
            Console.WriteLine($"{distinctGenres.Count()} distinct genres found: {string.Join(", ", distinctGenres.Select(g => g.Name).OrderBy(n => n))}");

            Console.WriteLine(Environment.NewLine + "Press enter to close.");
            Console.ReadLine();
        }
    }
}
