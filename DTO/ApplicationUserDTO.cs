using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]      
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
