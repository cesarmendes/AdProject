using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdProject.Web.Models;
using AdProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using AdProject.Domain.Entities;

namespace AdProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserManager { get; set; }
        public SignInManager<AppUser> SignInManager { get; set; }


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = UserManager.GetUserId(User);
                    var user = await UserManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        var result = await UserManager.ChangePasswordAsync(user,model.PasswordOld, model.Password);

                        if (result.Succeeded)
                        {
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!SignInManager.IsSignedIn(User))
                {
                    var result = await this.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(SiteController.Index), "Site");
                    }
                    else if (result.IsLockedOut)
                    {
                        return RedirectToAction(nameof(Lockout));
                    }
                    else if (result.RequiresTwoFactor)
                    {

                    }
                    else if (result.IsNotAllowed)
                    {

                    }
                    else
                    {
                        ModelState.AddModelError("", "Seus dados estão incorreto, por favor tente novamente.");
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Logoff()
        {
            await this.SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Site");
        }

        public IActionResult Lockout()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await this.UserManager.FindByNameAsync(model.Email);

                if (user != null)
                {
                    ModelState.AddModelError("", "Já existe um usuário cadastrado com essas informações!");
                }
                else
                {
                    var userIdentity = new Infrastructure.Identity.AppUser();
                    userIdentity.UserName = model.Email;
                    userIdentity.Email = model.Email;
                    userIdentity.Profile = new Profile();
                    userIdentity.Profile.Name = model.Name;

                    var result = await this.UserManager.CreateAsync(userIdentity, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(SiteController.Index), "Site");
                    }
                    else
                    {
                    }
                }
            }

            return View();
        }
    }
}