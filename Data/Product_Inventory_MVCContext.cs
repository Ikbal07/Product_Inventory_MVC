using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;

namespace Product_Inventory_MVC.Models
{
    //Connects and maps the model classes to tables.
    public class Product_Inventory_MVCContext : DbContext
    {
        public Product_Inventory_MVCContext (DbContextOptions<Product_Inventory_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Product_Inventory.Business.Product> Product { get; set; }

        public DbSet<Product_Inventory.Business.ProductCategory> ProductCategory { get; set; }

        public DbSet<Product_Inventory.Business.ProductRetailerRegistration> ProductRetailerRegistration { get; set; }

        public DbSet<Product_Inventory.Business.Retailer> Retailer { get; set; }
    }
}
