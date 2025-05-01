using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities.Identity;
using Project.Presentation.Utilities;
using Project.Presentation.ViewModels;

namespace Project.Presentation.Controllers;
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


    [HttpGet]
    public IActionResult ForgetPassword() => View();

    [HttpPost]
    public async Task<IActionResult> SendResetPasswordLink(ForgetPasswordViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByEmailAsync(viewModel.Email);
            if(user is not null)
            {
                //BaseUrl/Account/ResetPassword?email=..&token=...
                var resetPasswordLink = Url.Action("ResetPassword", "Auth", new
                {
                    email = viewModel.Email,
                    token = await userManager.GeneratePasswordResetTokenAsync(user)
                }, Request.Scheme);

                var email = new Email
                {
                    To = viewModel.Email,
                    Subject = "Reset Password",
                    Body = resetPasswordLink
                };
                EmailSettings.SendEmail(email);
                return RedirectToAction(nameof(CheckYourInbox));
            }
        }
        ModelState.AddModelError("", "Invalid Operation");
        return View(nameof(ForgetPassword), viewModel);
    }

    [HttpGet]
    public IActionResult CheckYourInbox() => View();

    [HttpGet]
    public IActionResult ResetPassword(string? email, string? token)
    {
        TempData["email"] = email;
        TempData["token"] = token;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
    {
        string? email = TempData["email"] as string;
        string? token = TempData["token"] as string;
        if (ModelState.IsValid && email is not null && token is not null)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                var result = await userManager.ResetPasswordAsync(user, token, viewModel.Password);
                if(result.Succeeded) return RedirectToAction(nameof(Login));
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(nameof(ResetPassword), viewModel);
                }
            }
        }
        ModelState.AddModelError("", "Invalid Operation");
        return View(nameof(Login));
    }
}
