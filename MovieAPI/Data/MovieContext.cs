﻿using Microsoft.EntityFrameworkCore;
using MovieAPI.Configurations;
using MovieAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.Entity<MovieDetails>()
                .Property(m => m.Budget)
                .HasPrecision(18, 2);
        }
    }
}
