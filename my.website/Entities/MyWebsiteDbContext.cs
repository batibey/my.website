using Microsoft.EntityFrameworkCore;

namespace my.website.Entities
{
    public class MyWebsiteDbContext: DbContext
    {
        public MyWebsiteDbContext(DbContextOptions<MyWebsiteDbContext> options) : base(options) { }  
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>().HasKey(p => p.Id);
            modelBuilder.Entity<Users>().HasKey(u => u.UserId);
        }
    }
}
