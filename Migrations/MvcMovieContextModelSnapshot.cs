﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MvcMovie.Models;
using System;

namespace MvcMovie.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    partial class MvcMovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcMovie.Models.Actor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthName");

                    b.Property<string>("Hometown");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("MvcMovie.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Image");

                    b.Property<decimal>("Price");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MvcMovie.Models.MovieRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActorID");

                    b.Property<string>("Character");

                    b.Property<int?>("MovieID");

                    b.HasKey("ID");

                    b.HasIndex("ActorID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieRole");
                });

            modelBuilder.Entity("MvcMovie.Models.MovieRole", b =>
                {
                    b.HasOne("MvcMovie.Models.Actor", "Actor")
                        .WithMany("Roles")
                        .HasForeignKey("ActorID");

                    b.HasOne("MvcMovie.Models.Movie", "Movie")
                        .WithMany("Roles")
                        .HasForeignKey("MovieID");
                });
#pragma warning restore 612, 618
        }
    }
}
