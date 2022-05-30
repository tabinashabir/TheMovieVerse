using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheMovieVerse.Model;

namespace TheMovieVerse.DB
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Hall> Halls { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
    }
}
