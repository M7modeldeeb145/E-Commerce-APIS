using E_Commerce.Data;
using E_Commerce.IRepository;
using E_Commerce.Models;

namespace E_Commerce.Repository
{
    public class ContactUsRepository : IContactUs
    {
        ApplicationDbContext context;
        public ContactUsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(ContactUs contactUs)
        {
            context.ContactUs.Add(contactUs);   
            context.SaveChanges();
        }

        public void delete(int id)
        {
            var delete = context.ContactUs.Find(id);
            if (delete != null)
            {
                context.ContactUs.Remove(delete);
                context.SaveChanges();
            }
        }

        public ContactUs Get(int id)
        {
            return context.ContactUs.Find(id);
        }

        public List<ContactUs> GetAll()
        {
            return context.ContactUs.ToList();
        }

        public void Update(ContactUs contactUs)
        {
            var result = context.ContactUs.Find(contactUs.Id);
            if (result != null)
            {
                result.Subject = contactUs.Subject;
                result.Status = contactUs.Status;
                result.Message = contactUs.Message;
                result.Email = contactUs.Email; 
                result.Name = contactUs.Name;
                context.SaveChanges();
            }
        }
    }
}
