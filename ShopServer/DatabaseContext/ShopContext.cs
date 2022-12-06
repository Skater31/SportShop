using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopServer.Models;

namespace ShopServer.DatabaseContext
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<SportItem> SportItems { get; set; }
    }
}
