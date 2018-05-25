using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            SeedMovies(serviceProvider);
            SeedActors(serviceProvider);
            SeedMovieRoles(serviceProvider);
        }

        private static void SeedMovies(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                var csv = new CsvReader(new StreamReader("C:/Users/phampaul/source/repos/MvcMovie/MvcMovie/SeedData/Movies.txt"));
                csv.Configuration.Delimiter = "|";
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                context.Movie.AddRange(
                    csv.GetRecords<Movie>()
                );
                context.SaveChanges();
            }
        }

        private static void SeedActors(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any Actors.
                if (context.Actor.Any())
                {
                    Console.WriteLine("Actors have been seeded");
                    return;   // DB has been seeded
                }

                Console.WriteLine("Seeding Actors");
                var csv = new CsvReader(new StreamReader("C:/Users/phampaul/source/repos/MvcMovie/MvcMovie/SeedData/Actors.txt"));
                csv.Configuration.Delimiter = "|";
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                context.Actor.AddRange(
                    csv.GetRecords<Actor>()
                );
                context.SaveChanges();
            }
        }

        private static void SeedMovieRoles(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movie roles.
                if (context.MovieRole.Any())
                {
                    return;   // DB has been seeded
                }

                var csv = new CsvReader(new StreamReader("C:/Users/phampaul/source/repos/MvcMovie/MvcMovie/SeedData/MovieRoles.txt"));
                csv.Configuration.Delimiter = "|";
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                context.MovieRole.AddRange(
                    csv.GetRecords<MovieRole>()
                );
                context.SaveChanges();
            }
        }
    }
}