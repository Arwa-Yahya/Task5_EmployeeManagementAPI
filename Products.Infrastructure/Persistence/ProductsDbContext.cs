
using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Infrastructure.Persistence
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(product => product.Id);

                entity.Property(product => product.Name)
                    .IsRequired();

                entity.Property(product => product.Price)
                    .HasPrecision(18, 2);
            });


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(employee => employee.Id);

                entity.Property(employee => employee.Name)
                    .IsRequired();

                entity.Property(employee => employee.Position)
                    .IsRequired();

                entity.Property(employee => employee.Salary)
                    .HasPrecision(18, 2);
            });

        }
    }
}
