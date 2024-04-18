using E_Commerce.IRepository;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        IContactUs repository;
        public ContactUsController(IContactUs repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("Get All Contacts")]
        public IActionResult GetAll()
        {
            var contacts = repository.GetAll();
            return Ok(contacts);
        }
        [HttpGet]
        [Route("Get Contact By Id")]
        public IActionResult Get(int id)
        {
            var contact = repository.Get(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Create Contact")]
        public IActionResult Create(ContactUs contact) 
        {
            if(ModelState.IsValid)
            {
                var con = new ContactUs()
                {
                    Email = contact.Email,
                    Id = contact.Id,
                    Name = contact.Name,
                    Message = contact.Message,
                    Status = contact.Status,
                    Subject = contact.Subject,
                };
                repository.Create(con);
                return Ok(con);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("Edit Contact")]
        public IActionResult Update(ContactUs contact)
        {
            if(ModelState.IsValid)
            {
                var con = repository.Get(contact.Id);
                if (con != null)
                {
                    repository.Update(con);
                    return Ok(con);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("Delete Contact")]
        public IActionResult Delete(int id)
        {
            var delete = repository.Get(id);
            if (delete != null)
            {
                repository.delete(id);
                return Ok(delete);
            }
            return NotFound();
        }
    }
}
