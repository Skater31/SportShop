using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportShop.Models;

namespace SportShop.DatabaseContext
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShopContext>());
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<SportItem> SportItems { get; set; }
    }
}
