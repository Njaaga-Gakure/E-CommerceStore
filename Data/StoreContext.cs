using E_CommerceStore.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceStore.Data
{
    public class StoreContext: DbContext 
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options){}

        public DbSet<Product> Products { get; set; }    
        public DbSet<Order> Orders { get; set; }    

    }
}
