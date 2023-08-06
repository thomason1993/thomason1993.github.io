using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TNTechnology.Business.Core;
using TNTechnology.Entity.Tables;

namespace TNTechnology.Entity
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configurations.ConnectionStrings.DefaultConnection);
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Admin_Roles> AdminRoles { get; set; }
        public DbSet<CategoryNews> CategoryNews { get; set; }
        public DbSet<Language> Language { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasData(
                    new Language()
                    {
                        Id = 1,
                        Code = "vi",
                        FullName = "Tiếng Việt",
                        IsDefault = true,
                        Flag = "flags/vietnam.svg"
                    },
                    new Language()
                    {
                        Id = 2,
                        Code = "en",
                        FullName = "English",
                        IsDefault = false,
                        Flag = "flags/united-kingdom.svg"
                    }
                );
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasData(
                    new Roles()
                    {
                        Id = 1,
                        FullName = "Full control"
                    }
                );
            });

            modelBuilder.Entity<CategoryNews>(entity =>
            {
                entity.Property(e => e.MainImage)
                    .HasDefaultValueSql($"(N'{AppEnums.DefaultImage.Img.GetDescription()}')");
                entity.Property(e => e.LayoutIndex)
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql($"(({AppEnums.Status.Active.GetHashCode()}))");
                entity.Property(e => e.DateCreate)
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDelete)
                    .HasDefaultValueSql($"((0))");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Avatar)
                    .HasDefaultValueSql($"(N'{AppEnums.DefaultImage.Girl.GetDescription()}')");
                entity.Property(e => e.Sex)
                    .HasDefaultValueSql($"(({AppEnums.Sex.Female.GetHashCode()}))");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql($"(({AppEnums.Status.Active.GetHashCode()}))");
                entity.Property(e => e.DateCreate)
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDelete)
                    .HasDefaultValueSql($"((0))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Avatar)
                    .HasDefaultValueSql($"(N'{AppEnums.DefaultImage.Girl.GetDescription()}')");
                entity.Property(e => e.Sex)
                    .HasDefaultValueSql($"(({AppEnums.Sex.Female.GetHashCode()}))");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql($"(({AppEnums.Status.Active.GetHashCode()}))");
                entity.Property(e => e.DateCreate)
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDelete)
                    .HasDefaultValueSql($"((0))");
            });
        }

    }
}
