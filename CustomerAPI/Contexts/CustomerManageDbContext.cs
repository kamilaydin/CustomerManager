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

      
    }


    class CustomerManageSqlServerDbContext : DbContext
    {

    }
}

