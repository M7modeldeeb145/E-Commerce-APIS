using E_Commerce.DTO;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public static class ConvertFromApplicationUserToDTO
    {
        public static ApplicationUserDTO Convert(ApplicationUser user)
        {
            ApplicationUserDTO productDTO = new ApplicationUserDTO
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,   
                Password = user.PasswordHash
            };
            return productDTO;
        }
        public static List<ApplicationUserDTO> ConvertList(List<ApplicationUser> users) 
        {
            List<ApplicationUserDTO> applicationUsersDTO = new List<ApplicationUserDTO>();
            foreach (ApplicationUser user in users)
            {
                ApplicationUserDTO userDTO = new ApplicationUserDTO()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.PasswordHash
                };
                applicationUsersDTO.Add(userDTO);
            }
            return applicationUsersDTO;
        }
    }
}
