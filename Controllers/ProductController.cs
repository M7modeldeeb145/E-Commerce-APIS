using E_Commerce.DTO;
using E_Commerce.IRepository;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        IProduct repository;
        public ProductController(IProduct repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("Get All Products")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var products = repository.GetAll();
            return Ok(ConvertFromProductToDTO.ConvertList(products));
        }
        [HttpGet]
        [Route("Get Product By Id")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            var product = repository.GetById(id);
            if (product != null)
            {
                return Ok(ConvertFromProductToDTO.Convert (product));
            }
            return NotFound();
        }
        [HttpGet]
        [Route("Search")]
        [AllowAnonymous]
        public IActionResult Search(string keyword)
        {
            var search = repository.Search(keyword);
            if (search.Count!=0)
            {
                return Ok(ConvertFromProductToDTO.ConvertList(search));
            }
            return new BadRequestObjectResult("No Matching Found");
        }
        [HttpDelete]
        [Route("Delete Product")]
        public IActionResult Delete(int id)
        {
            var product = repository.GetById(id);
            if (product != null)
            {
                repository.Delete(id); 
                return Ok(ConvertFromProductToDTO.Convert(product));
            }
            return new BadRequestObjectResult("No Matching Product");
        }
        [HttpPost]
        [Route("Create New Product")]
        public IActionResult Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var prod = new Product()
                {
                    Name = productDTO.Name,
                    Discount = productDTO.Discount,
                    Model = productDTO.Model,
                    CategoryID = productDTO.CategoryID,
                    Price = productDTO.Price,
                    Description = productDTO.Description
                };
                List<string> productImages = new List<string>();
                foreach (var item in prod.ProductImages)
                {
                    productImages.Add(item.ImageUrl);
                }
                productDTO.ProductImages.AddRange(productImages);
                repository.Create(prod);
                return Ok(ConvertFromProductToDTO.Convert(prod));
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("Update Product")]
        public IActionResult Update(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = repository.GetById(productDTO.Id);
                if(product != null)
                {
                    repository.Update(product);
                    return Ok(ConvertFromProductToDTO.Convert(product));
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("Get Products By CategoryId")]
        public IActionResult GetProducts(int id)
        {
            var products = repository.GetProductByCatId(id);
            return Ok(ConvertFromProductToDTO.ConvertList(products));
        }
    }
}
