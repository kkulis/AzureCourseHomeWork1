using KursAzureZad1.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace KursAzureZad1.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
    }
}
