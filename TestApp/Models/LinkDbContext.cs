using Microsoft.EntityFrameworkCore;

namespace TestApp.Models
{
    public class LinkDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DB_TestApp.db");
        }
    }
}