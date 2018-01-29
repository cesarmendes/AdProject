using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdProject.Web.Models;
using AdProject.Infraestrutura.Identity;
using Microsoft.AspNetCore.Identity;
using AdProject.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace AdProject.Web.Controllers
{
    [AllowAnonymous]
    public class ContaController : Controller
    {
        private ILogger<ContaController> Logger { get; set; }
        private UserManager<AppUser> UserManager { get; set; }
        private SignInManager<AppUser> SignInManager { get; set; }

        public ContaController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<ContaController> logger)
        {
            this.Logger = logger;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult TrocarSenha()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrocarSenha(ChangePasswordViewModel model)
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
        public IActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entrar(LoginViewModel model)
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
                        return RedirectToAction(nameof(Bloqueio));
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
        public IActionResult Bloqueio()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(RegisterViewModel model)
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
                    var userIdentity = new Infraestrutura.Identity.AppUser();
                    userIdentity.UserName = model.Email;
                    userIdentity.Email = model.Email;
                    userIdentity.Profile = new Perfil();
                    userIdentity.Profile.Nome = model.Name;

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