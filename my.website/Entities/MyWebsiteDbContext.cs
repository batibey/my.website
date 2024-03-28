using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using my.website.Entities;

namespace my.website.Data
{
    public class MyWebsiteDbContext : IdentityDbContext<Users> 
    {
        public MyWebsiteDbContext(DbContextOptions<MyWebsiteDbContext> options) : base(options)
        {
        }

        public DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Projects>().HasKey(p => p.Id);
            modelBuilder.Entity<Users>().HasKey(u => u.UserId);
        }
    }
}
