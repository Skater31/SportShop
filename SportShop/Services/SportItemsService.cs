using SportShop.DatabaseContext;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace SportShop.Services
{
    public class SportItemsService : ISportItemsService
    {
        private readonly ShopContext _shopContext;

        public SportItemsService()
        {
            _shopContext = new ShopContext();
        }

        public IEnumerable<SportItem> Find(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return _shopContext.SportItems.ToList();
            }

            var items = new List<SportItem>();

            var sportItems = _shopContext.SportItems;

            value = value.Trim().ToLower();

            foreach (var sportItem in sportItems)
            {
                if (sportItem.ShopId.ToString().ToLower().Contains(value) ||
                    sportItem.Name.Contains(value) ||
                    sportItem.Count.ToString().ToLower().Contains(value) ||
                    sportItem.Price.ToString().ToLower().Contains(value) ||
                    sportItem.Category.ToString().ToLower().Contains(value))
                {
                    items.Add(sportItem);
                }
            }

            return items;
        }

        public IEnumerable<SportItem> GetCatalog(int shopId)
        {
            var catalog = new List<SportItem>();

            var sportItems = _shopContext.SportItems.Where(p => p.ShopId == shopId);

            foreach (var sportItem in sportItems)
            {
                catalog.Add(sportItem);
            }

            return catalog;
        }

        public void Add(SportItem sportItem)
        {
            _shopContext.SportItems.Add(sportItem);

            _shopContext.SaveChanges();
        }

        public void Edit(SportItem sportItem)
        {
            _shopContext.SportItems.AddOrUpdate(sportItem);

            _shopContext.SaveChanges();
        }
    }
}
