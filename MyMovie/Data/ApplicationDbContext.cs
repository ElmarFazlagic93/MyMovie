using MyMovie.Models;
using System.Data.Entity;

namespace MyMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :
          base("MyMovieConnectionString")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}