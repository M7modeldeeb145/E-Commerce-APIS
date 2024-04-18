using E_Commerce.Models;

namespace E_Commerce.IRepository
{
    public interface IContactUs
    {
        void delete (int id);
        void Create (ContactUs contactUs);
        void Update (ContactUs contactUs);
        List<ContactUs> GetAll ();
        ContactUs Get (int id); 
    }
}
