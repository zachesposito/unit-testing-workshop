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
            foreach (var movie in movieService.GetTopPopularMovies(5))
            {
                Console.WriteLine(movie.GetDescription() + Environment.NewLine);
            }

            Console.WriteLine("*********************");
            Console.WriteLine("Type in search critera:");
            string search = Console.ReadLine();

            Console.WriteLine("*********************");
            Console.WriteLine("SEARCH RESULTS (MAX - 5 MOVIES)");
            Console.WriteLine("*********************");
            foreach (var movie in movieService.SearchTag(search).Take(5))
            {
                Console.WriteLine(movie.GetDescription() + Environment.NewLine);
            }

            Console.WriteLine("*********************");
            Console.WriteLine(Environment.NewLine + "Press enter to close.");
            Console.ReadLine();
        }
    }
}
