using E_Commerce.Models;

namespace E_Commerce.IRepository
{
    public interface IProduct
    {
        void Delete (int id);
        void Update(Product product);
        List<Product> GetAll ();
        Product GetById (int id);
        void Create (Product product);
        List<Product> Search(string name);
        List<Product> GetProductByCatId(int id);
    }
}
