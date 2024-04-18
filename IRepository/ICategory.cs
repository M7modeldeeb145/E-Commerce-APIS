using E_Commerce.Models;

namespace E_Commerce.IRepository
{
    public interface ICategory
    {
        void Update (Category category);
        void Delete (int id);   
        void Create (Category category);
        List<Category> GetAll ();
        Category GetById (int id);
    }
}
