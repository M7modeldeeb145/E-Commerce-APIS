using E_Commerce.DTO;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Regesteration(ApplicationUserDTO applicationUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = applicationUser.Email,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Email = applicationUser.Email,
                    PasswordHash = applicationUser.Password
                };
                var result = await userManager.CreateAsync(user, applicationUser.Password);
                if (result.Succeeded)
                {
                   //await signInManager.SignInAsync(user, false);
                    return new OkObjectResult("User Register Successfully ");
                }
                return new BadRequestObjectResult("There was an error processing your request, please try again."); ;
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.FindByEmailAsync(userDTO.Email);
                if (result != null)
                {
                    bool check =await userManager.CheckPasswordAsync(result, userDTO.Password);
                    if (check)
                    {
                        await signInManager.SignInAsync(result, userDTO.RemeberMe);
                        return new OkObjectResult("User LoggedIn Successfully");
                    }
                    return new BadRequestObjectResult("Invalid Password");
                }
                return new BadRequestObjectResult("Invalid Email");
            }
            return BadRequest(userDTO);
        }
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return new OkObjectResult("User LoggedOut Successfully");
        }
    }
}
