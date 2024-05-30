using FinanceKnowHow.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceKnowHow.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL8006.site4now.net;Initial Catalog=db_a9b483_loyversdata;User Id=db_a9b483_loyversdata_admin;Password=243243Godi");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>();
        }
    }
}
