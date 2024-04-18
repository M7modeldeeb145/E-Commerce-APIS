using E_Commerce.Models;

namespace E_Commerce.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public List<string> ProductImages { get; set; } = new List<string>();
    }
}
