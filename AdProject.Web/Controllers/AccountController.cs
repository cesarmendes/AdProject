using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdProject.Web.Models;
using AdProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using AdProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace AdProject.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private ILogger<AccountController> Logger { get; set; }
        private UserManager<AppUser> UserManager { get; set; }
        private SignInManager<AppUser> SignInManager { get; set; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            this.Logger = logger;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                Logger.LogInformation("inícios do método ChangePassword com o parametro {model}", model);

                if (ModelState.IsValid)
                {
                    var id = UserManager.GetUserId(User);
                    var user = await UserManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        var result = await UserManager.ChangePasswordAsync(user,model.PasswordCurrent, model.Password);

                        if (result.Succeeded)
                        {

                        }
                    }

                }

                Logger.LogInformation("fim do método ChangePassword com o parametro {model}", model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{model}" , model);
            }

            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByNameAsync(model.Email);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, nameof(ForgotPassword), model);
            }


            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        public async Task<IActionResult> Logoff()
        {
            await this.SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Site");
        }

        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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