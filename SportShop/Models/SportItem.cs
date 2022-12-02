using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportShop.Enums;

namespace SportShop.Models
{
    public class SportItem
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
