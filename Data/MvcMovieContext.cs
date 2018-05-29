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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Actor>()
        //        .HasMany(a => a.Roles)
        //        .WithOne(r => r.Actor)
        //        //.HasPrincipalKey(a => a.Name)
        //        //.HasForeignKey(r => r.ActorName)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    modelBuilder.Entity<Movie>()
        //        .HasMany(m => m.Roles)
        //        .WithOne(r => r.Movie)
        //        //.HasPrincipalKey(m => m.Title)
        //        //.HasForeignKey(r => r.MovieTitle)
        //        .OnDelete(DeleteBehavior.SetNull);

        //}
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }

        public DbSet<MvcMovie.Models.Actor> Actor { get; set; }

        public DbSet<MvcMovie.Models.MovieRole> MovieRole { get; set; }
    }
}
