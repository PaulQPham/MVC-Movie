using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Models
{
    public class MvcMovieContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.MovieRoles)
                .WithOne(r => r.Actors)
                //.HasPrincipalKey(a => a.Name)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.MovieRoles)
                .WithOne(r => r.Movies)
                //.HasPrincipalKey(m => m.Title)
                .OnDelete(DeleteBehavior.Cascade);

        }
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }

        public DbSet<MvcMovie.Models.Actor> Actor { get; set; }

        public DbSet<MvcMovie.Models.MovieRole> MovieRole { get; set; }
    }
}
