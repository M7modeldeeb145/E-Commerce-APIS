using E_Commerce.DTO;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class ConvertFromCategoryToDTO
    {
        public static List<CategoryDTO> ConvertList(List<Category> categories)
        {
            List<CategoryDTO> categorysDTO = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                CategoryDTO categoryDTO = new CategoryDTO()
                {
                    Id = category.Id,
                    Name = category.Name,
                };
                categorysDTO.Add(categoryDTO);
            }
            return categorysDTO;
        }
        public static CategoryDTO Convert(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryDTO;
        }
    }
}
