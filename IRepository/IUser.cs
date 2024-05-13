using E_Commerce.Models;

namespace E_Commerce.IRepository
{
    public interface IUser
    {
        List<ApplicationUser> GetAll();
    }
}
