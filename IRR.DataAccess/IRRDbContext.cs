using IRR.Core;
using IRR.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IRR.DataAccess
{
    public class IRRDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<CategoryField> CategoryFields { get; set; }

        public IRRDbContext(DbContextOptions<IRRDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryItemFieldConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryFieldTypeConfiguration());


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "АИС"
                },
                new Category
                {
                    Id = 2,
                    Name = "АО",
                    ParentId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "ПО",
                    ParentId = 1
                });
        }
    }
}
