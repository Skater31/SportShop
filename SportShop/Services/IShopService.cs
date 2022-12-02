using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportShop.Models;

namespace SportShop.Services
{
    public interface IShopService
    {
        Shop GetShop(string login, string password);
    }
}
