using E_Commerce.Data;
using E_Commerce.IRepository;
using E_Commerce.Models;

namespace E_Commerce.Repository
{
    public class UserRepository : IUser
    {
        ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<ApplicationUser> GetAll()
        {
            return context.Users.ToList();
        }
    }
}
