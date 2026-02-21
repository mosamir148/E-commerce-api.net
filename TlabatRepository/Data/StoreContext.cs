using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;
using TalabatCore.Entites.Order_Agreggate;

namespace TlabatRepository.Data
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
        
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<ProductBrand> productBrands { get; set; }

        public DbSet<ProductType> productTypes { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<DeliveryMethode> deliveryMethodes { get; set; }

        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Order> orders { get; set; }

      
       
    }
    
}
