using Lezlab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lezlab.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

   
}
