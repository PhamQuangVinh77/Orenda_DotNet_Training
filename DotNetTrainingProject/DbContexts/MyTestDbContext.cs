using DotNetTrainingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainingProject.DbContexts
{
    public class MyTestDbContext : DbContext
    {
        public MyTestDbContext() { }
        public MyTestDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductGroup>(p => p.Property(q => q.Description).HasColumnType("text"));
            modelBuilder.Entity<ProductGroup>(p => p.Property(q => q.CreatedDate).HasColumnType("datetime"));

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>(p => p.Property(q => q.Price).HasColumnType("decimal(18, 2)"));
            modelBuilder.Entity<Product>(p => p.Property(q => q.CreatedDate).HasColumnType("datetime"));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
