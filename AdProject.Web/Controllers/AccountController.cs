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
        private  UserManager<UserIdentity> UserManager { get; set; }
        public SignInManager<UserIdentity> SignInManager { get; set; }


        public AccountController(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
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
                var result = await this.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.Connected, true);

                if (result.Succeeded)
                {
                }
                else if (result.IsLockedOut)
                {
                }
                else if (result.RequiresTwoFactor)
                {

                }
                else if (result.IsNotAllowed)
                {

                }
            }

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
                }
                else
                {
                    var userIdentity = new UserIdentity();
                    userIdentity.UserName = model.Email;
                    userIdentity.Email = model.Email;
                    userIdentity.Profile = new Profile();
                    userIdentity.Profile.Name = model.Name;

                    var result = await this.UserManager.CreateAsync(userIdentity, model.Password);

                    if (result.Succeeded)
                    {
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