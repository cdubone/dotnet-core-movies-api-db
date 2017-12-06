using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MoviesAPI.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new MoviesAPIContext(
                serviceProvider.GetRequiredService<DbContextOptions<MoviesAPIContext>>());
            context.Database.EnsureCreated();
        }
    }
}