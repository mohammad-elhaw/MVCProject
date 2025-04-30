using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities.Identity;
using Project.Presentation.ViewModels;

namespace Project.Presentation.Controllers
{
    public class AuthController(
        UserManager<User> userManager,
        SignInManager<User> signInManager) : Controller
    {
        [HttpGet]
        public IActionResult Register() => View();
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if(!ModelState.IsValid) return View(viewModel);

            var user = new User
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel?.LastName,
                UserName = viewModel.UserName,
                Email = viewModel.Email,
            };

            var result = await userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded) return RedirectToAction("Login");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if(viewModel is null) return View();
            if (!ModelState.IsValid) return View(viewModel);
            
            var user = await userManager.FindByEmailAsync(viewModel.Email);

            if(user is not null)
            {
                bool isValidPassword = await userManager.CheckPasswordAsync(user, viewModel.Password);
                if(isValidPassword)
                {
                    var result = await signInManager
                        .PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);

                    if (result.IsNotAllowed)
                        ModelState.AddModelError("", "Your account is not allowed");
                    if (result.IsLockedOut)
                        ModelState.AddModelError("", "Your account is locked");
                    if (result.Succeeded)
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            else
                ModelState.AddModelError("", "Invalid Login");
            return View(viewModel);
        }
        
    }
}
