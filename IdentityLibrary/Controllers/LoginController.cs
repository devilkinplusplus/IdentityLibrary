using IdentityLibrary.Entities;
using IdentityLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace IdentityLibrary.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]//Sign In Operation
        public async Task<IActionResult> Signin(UserSigninVM model)
        {
            if (ModelState.IsValid)
            {
         
               var signin= await signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
                if (signin.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else if (signin.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Method is not allowed");
                }
            }

            return View(model);
        }
    }
}
