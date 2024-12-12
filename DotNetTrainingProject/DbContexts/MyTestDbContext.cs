using DotNetTrainingProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainingProject.DbContexts
{
    public class MyTestDbContext : IdentityDbContext<ApplicationUser>
    {
        private const string DEFAULT_ADMIN_PASSWORD = "Admin123@";
        private IPasswordHasher<ApplicationUser> _passwordHasher;
        public MyTestDbContext(DbContextOptions<MyTestDbContext> options, IPasswordHasher<ApplicationUser> passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Set type ProductGroup
            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductGroup>(p => p.Property(q => q.Description).HasColumnType("text"));
            modelBuilder.Entity<ProductGroup>(p => p.Property(q => q.CreatedDate).HasColumnType("datetime"));

            // Set type Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>(p => p.Property(q => q.Price).HasColumnType("decimal(18, 2)"));
            modelBuilder.Entity<Product>(p => p.Property(q => q.CreatedDate).HasColumnType("datetime"));

            // Set type ApplicationUser
            modelBuilder.Entity<ApplicationUser>().Property(p => p.FullName).HasColumnType("varchar(255)").IsRequired(false);
            modelBuilder.Entity<ApplicationUser>().Property(p => p.Address).HasColumnType("varchar(255)").IsRequired(false);
            modelBuilder.Entity<ApplicationUser>().Property(p => p.ProfilePictureUrl).HasColumnType("varchar(255)").IsRequired(false);
            modelBuilder.Entity<ApplicationUser>().Property(p => p.Description).HasColumnType("text").IsRequired(false);

            //Seeding data
            SeedData(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seeding admin data
            var adminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" };
            var admin = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                FullName = "Boss Admin",
                DateOfBirth = DateTime.Now,
                Address = "Hanoi",
                ProfilePictureUrl = "",
                Description = "It's boss's account",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            admin.PasswordHash = _passwordHasher.HashPassword(admin, DEFAULT_ADMIN_PASSWORD);

            // Insert admin account to table
            modelBuilder.Entity<IdentityRole>().HasData(
                    adminRole,
                    new IdentityRole() { Name = "Customer", ConcurrencyStamp = "2", NormalizedName = "Customer" }
            );
            modelBuilder.Entity<ApplicationUser>().HasData(admin);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>() { RoleId = adminRole.Id, UserId = admin.Id });
        }
    }
}
