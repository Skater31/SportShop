using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Services
{
    public interface ISportItemService
    {
        Task<IEnumerable<SportItem>> Find(string value);

        Task<IEnumerable<SportItem>> GetCatalog(int shopId);

        void Add(SportItem sportItem);

        void Edit(SportItem sportItem);
    }
}
