using E_Commerce.Data;
using E_Commerce.IRepository;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository
{
    public class ProductRepository : IProduct
    {
        ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context; 
        }
        public void Create(Product product)
        {
            context.Products.Add(product);  
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return context.Products.Include(e=>e.Category).Include(e=>e.ProductImages).ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Include(e=>e.ProductImages).First(e=>e.Id==id);
        }

        public List<Product> GetProductByCatId(int id)
        {
            return context.Products.Include(e=>e.ProductImages).Where(e=>e.CategoryID==id).ToList();
        }

        public List<Product> Search(string name)
        {
            return context.Products.Include(e=>e.ProductImages).Include(e=>e.Category).Where(e=>e.Name.Contains(name)).ToList();
        }

        public void Update(Product product)
        {
            var prod = context.Products.Find(product.Id);
            if (prod != null)
            {
                prod.Price = product.Price;
                prod.Name = product.Name;
                prod.Description = product.Description;
                prod.CategoryID = product.CategoryID;
                prod.Model = product.Model;
                prod.Discount = product.Discount;
                //prod.ProductImages = product.ProductImages;
                context.SaveChanges();
            }
        }
    }
}
