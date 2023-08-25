using Microsoft.EntityFrameworkCore;
using TOYOTA.Model.Entities;

namespace TOYOTA.DataAccess.Implementations.EF.Contexts
{
    public class ToyotaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=Toyota;trusted_connection=true;");
        }

        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<SparePart>? SpareParts { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<AdminPanelUser>? AdminPanelUsers { get; set; }
    }
}
