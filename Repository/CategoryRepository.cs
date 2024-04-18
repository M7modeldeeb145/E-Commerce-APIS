using E_Commerce.Data;
using E_Commerce.IRepository;
using E_Commerce.Models;

namespace E_Commerce.Repository
{
    public class CategoryRepository : ICategory
    {
        ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Category = context.Categories.Find(id);
            if (Category != null)
            {
                context.Categories.Remove(Category);
                context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public void Update(Category category)
        {
            var cat = context.Categories.Find(category.Id);
            if (cat != null)
            {
                cat.Name = category.Name;
                context.SaveChanges();
            }
        }
    }
}
