using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Services
{
    public interface ISportItemsService
    {
        IEnumerable<SportItem> Find(string value);

        IEnumerable<SportItem> GetCatalog(int shopId);

        void Add(SportItem sportItem);

        void Edit(SportItem sportItem);
    }
}
