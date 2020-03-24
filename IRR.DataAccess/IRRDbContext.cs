using IRR.Core;
using IRR.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IRR.DataAccess
{
    public class IRRDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public IRRDbContext(DbContextOptions<IRRDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        //    modelBuilder.Entity<Category>().HasData(new Category
        //    {
        //        Id = 1,
        //        Name = "Оргтехника"
        //    },
        //        new Category
        //        {
        //            Id = 2,
        //            Name = "Мебель"
        //        });
        //}
    }
}
