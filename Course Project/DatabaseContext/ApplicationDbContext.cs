using Course_Project.Models;
using Course_Project.Repository.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Course_Project.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CustomersEntity> Customers { get; set; }
        public DbSet<PaymentsEntity> Payments { get; set; }
        public DbSet<ReturnsEntity> Returns { get; set; }
        public DbSet<SellersEntity> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomersEntity>()
            .HasOne(e => e.Payment)
            .WithOne(e => e.Customer)
            .HasForeignKey<PaymentsEntity>(e => e.CustomerId)
            .IsRequired();

            modelBuilder.Entity<CarEntity>()
            .HasOne(e => e.Returns)
               .WithOne(e => e.Car)
            .HasForeignKey<ReturnsEntity>(e => e.CarId);

            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ReturnConfiguration());
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
        }
    }
}
