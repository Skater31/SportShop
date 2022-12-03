using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportShop.DatabaseContext;
using SportShop.Models;

namespace SportShop.Services
{
    public class ShopService : IShopService
    {
        private readonly ShopContext _shopContext;

        public ShopService()
        {
            _shopContext = new ShopContext();
        }

        public Shop GetShop(string login, string password)
        {
            if (IsCorrectAuthorization(ref login, ref password))
            {
                return _shopContext.Shops.FirstOrDefault(m => m.Login == login && m.Password == password);
            }

            return null;
        }

        private bool IsCorrectAuthorization(ref string login, ref string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return true;
        }
    }
}
