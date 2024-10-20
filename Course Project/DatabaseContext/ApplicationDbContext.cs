using Course_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_Project.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CustomersEntity> Customers { get; set; }
        public DbSet<DeliveryEntity> Deliveries { get; set; }
        public DbSet<PaymentsEntity> Payments { get; set; }
        public DbSet<ReturnsEntity> Returns { get; set; }
        public DbSet<SellersEntity> Sellers { get; set; }
        public DbSet<SuppliersEntity> Suppliers { get; set; }
    }
}
