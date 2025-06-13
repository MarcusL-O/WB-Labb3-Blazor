
using labb3_Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace labb3_Blazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Technology> Tech { get; set; }


    }
}