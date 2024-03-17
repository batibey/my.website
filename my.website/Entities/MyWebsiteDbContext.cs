using Microsoft.EntityFrameworkCore;

namespace my.website.Entities
{
    public class MyWebsiteDbContext: DbContext
    {
        public MyWebsiteDbContext(DbContextOptions<MyWebsiteDbContext> options) : base(options) { }  
        public DbSet<Projects> Projects { get; set; }
    }
}
