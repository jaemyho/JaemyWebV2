using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JaemyPortfolio.Models;

namespace JaemyPortfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure entities
            builder.Entity<ContactMessage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Subject).HasMaxLength(200);
                entity.Property(e => e.Message).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP()");
            });

            builder.Entity<BlogPost>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Author).HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP()");
                entity.Property(e => e.IsPublished).HasDefaultValue(false);
            });

            builder.Entity<PortfolioItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.ProjectUrl).HasMaxLength(500);
                entity.Property(e => e.GitHubUrl).HasMaxLength(500);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.Technologies).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP()");
            });
        }
    }
}
