using System.Data;
using DotNetTrainingProject.Entities;
using DotNetTrainingProject.MailUtilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace DotNetTrainingProject.DbContexts
{
    public class MyTestDbContext : IdentityDbContext<ApplicationUser>
    {
        private MailSettings _mailSettings;
        private IPasswordHasher<ApplicationUser> _passwordHasher;
        private IConfiguration _configuration;
        public MyTestDbContext(DbContextOptions<MyTestDbContext> options, IPasswordHasher<ApplicationUser> passwordHasher,
            IOptions<MailSettings> mailSettings, IConfiguration configuration) : base(options)
        {
            _passwordHasher = passwordHasher;
            _mailSettings = mailSettings.Value;
            _configuration = configuration;
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

        public IDbConnection CreateConnection() => new MySqlConnection(_configuration.GetConnectionString("TestDb"));

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seeding admin data
            var adminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" };
            var admin = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                Email = _mailSettings.Mail,
                FullName = "Boss Admin",
                DateOfBirth = DateTime.Now,
                Address = "Hanoi",
                ProfilePictureUrl = "",
                Description = "It's boss's account",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            admin.NormalizedUserName = admin.UserName.ToUpper();
            admin.NormalizedEmail = admin.Email.ToUpper();
            admin.PasswordHash = _passwordHasher.HashPassword(admin, "Admin123@");

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
