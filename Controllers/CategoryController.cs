using E_Commerce.DTO;
using E_Commerce.IRepository;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategory repository;
        public CategoryController(ICategory repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("Show All Categories")]
        public IActionResult GetAll()
        {
            var categories = repository.GetAll();
            return Ok(ConvertFromCategoryToDTO.ConvertList(categories));
        }
        [HttpGet]
        [Route("Get Category By Id")]
        public IActionResult Get(int id)
        {
            var category = repository.GetById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("Create New Category")]
        public IActionResult Create (CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var category = new Category() 
                {
                    Id = categoryDTO.Id,
                    Name = categoryDTO.Name
                };
                repository.Create(category);
                return Ok(category);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("Update Category")]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            if(ModelState.IsValid)
            {
                var category = repository.GetById(categoryDTO.Id);
                if (category != null)
                {
                    repository.Update(category);
                    return Ok(ConvertFromCategoryToDTO.Convert(category));
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("Delete Category")]
        public IActionResult Delete(int id)
        {
            var category = repository.GetById(id);
            if (category != null)
            {
                repository.Delete(id);
                return Ok(ConvertFromCategoryToDTO.Convert(category));
            }
            return NotFound();  
        }
    }
}
