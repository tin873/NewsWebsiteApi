using Microsoft.EntityFrameworkCore;
using NewsWebsite.Core.Entities;

namespace NewsWebsite.DataAccessLayer
{
    public class NewsWebsiteDbContext : DbContext
    {
        public NewsWebsiteDbContext(DbContextOptions<NewsWebsiteDbContext> options) : base(options)
        { }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Post>().ToTable("Post");

            modelBuilder.Entity<Post>()
            .HasOne<Category>(s => s.Category)
            .WithMany(g => g.Posts)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
