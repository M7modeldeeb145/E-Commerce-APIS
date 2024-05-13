using E_Commerce.DTO;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public static class ConvertFromProductToDTO
    {
        public static ProductDTO Convert(Product product)
        {
            ProductDTO productDTO = new ProductDTO()
            {
                CategoryID = product.CategoryID,
                Name = product.Name,
                Description = product.Description,
                Discount = product.Discount,
                Id= product.Id,
                Price = product.Price,
                Model = product.Model,
                //ProductImages = product.ProductImages
            };
            List<string> productImages = new List<string>();
            foreach (var item in product.ProductImages)
            {
                productImages.Add(item.ImageUrl);
            }
            productDTO.ProductImages.AddRange(productImages);
            return productDTO;
        }
        public static List<ProductDTO> ConvertList(List<Product> products)
        {
            List<ProductDTO> productsDTO = new List<ProductDTO>();
            foreach (Product product in products)
            {
                ProductDTO productDTO = new ProductDTO()
                {
                    CategoryID= product.CategoryID,
                    Name = product.Name,
                    Price=product.Price,
                    Model=product.Model,
                    Id = product.Id,
                    Description = product.Description,
                    Discount = product.Discount,
                    //ProductImages = product.ProductImages
                };

                List<string> productImages = new List<string>();
                foreach (var item in product.ProductImages)
                {
                    productImages.Add(item.ImageUrl);
                }
                productDTO.ProductImages.AddRange(productImages);
                productsDTO.Add(productDTO);
            }
            return productsDTO;
        }
    }
}
