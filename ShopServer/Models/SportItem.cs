using ShopServer.Enums;

namespace ShopServer.Models
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
