using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Models
{
    public class MoviesAPIContext : DbContext
    {
        public MoviesAPIContext (DbContextOptions<MoviesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesAPI.Models.Movie> Movie { get; set; }
    }
}