using E_Commerce.DTO;
using E_Commerce.IRepository;
using E_Commerce.Models;
using E_Commerce.Repository;
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
        IUser repository;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUser repository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repository = repository;
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
        [HttpGet]
        [Route("Get Account Details")]
        public async Task<IActionResult> Get()
        {
            var result = await userManager.GetUserAsync(User);
            if (result != null)
            {
                return Ok(result);
            }
            return new BadRequestObjectResult("Please Login First");
        }
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(ApplicationUserDTO updatedUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(updatedUser.Email);
                if (existingUser != null)
                {
                    // Update user properties
                    existingUser.FirstName = updatedUser.FirstName;
                    existingUser.LastName = updatedUser.LastName;

                    // Update user in the database
                    var result = await userManager.UpdateAsync(existingUser);
                    if (result.Succeeded)
                    {
                        return new OkObjectResult("User information updated successfully");
                    }
                    else
                    {
                        return new BadRequestObjectResult("Failed to update user information");
                    }
                }
                else
                {
                    return new BadRequestObjectResult("User not found");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("Get All Users")]
        public IActionResult GetAll()
        {
            var users = repository.GetAll();
            return Ok(users);
        }
    }
}
