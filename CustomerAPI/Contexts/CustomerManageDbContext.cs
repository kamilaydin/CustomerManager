using CustomerAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Contexts
{
    public class CustomerManageDbContext : DbContext
    {
        public CustomerManageDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Phone> Phones { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=CustomerManageDB;");
        //}
    }


    class CustomerManageSqlServerDbContext : DbContext
    {

    }
}

