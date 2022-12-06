using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShopServer.DatabaseContext;
using ShopServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ShopServer.Services
{
    public class ShopService
    {
        private readonly ShopContext _shopContext;

        public ShopService(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public Shop GetShop(string login, string password)
        {
            return _shopContext.Shops.FirstOrDefault(m => m.Login == login && m.Password == password);
        }
    }
}
