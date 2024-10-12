using IranKish.UrlShortener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Emit;
namespace IranKish.UrlShortener.Persistance.Ef.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<UrlEntry> Urls { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            builder.Entity<UrlEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable(nameof(UrlEntry));
            });
            base.OnModelCreating(builder);
        }

    }
}
