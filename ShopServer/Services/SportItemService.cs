using ShopServer.Models;
using ShopServer.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ShopServer.Services
{
    public class SportItemService
    {
        private readonly ShopContext _shopContext;

        public SportItemService(ShopContext shopContext)
        {
            _shopContext = shopContext;
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
            _shopContext.Entry(sportItem).State = EntityState.Modified;

            _shopContext.SaveChanges();
        }
    }
}
