using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDrive.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDrive.ViewModels;
using WebApplication1.Models;
using RDrive.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using RDrive.BusinessLogic.Providers.Interfaces;
using RDrive.BusinessLogic.Providers;
using RDrive.Shared.Constants;
using RDrive.Shared.Exceptions.BusinessLogicExceptions;
using RDrive.BusinessLogic.Services;
using RDrive.ViewModels.AccountViewModels;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService userService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IEmailProvider emailProvider ;

        public UserController(IAccountService userService, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new UserLoginVM { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterNewUserAccountView userRegister)
        {
            try
            {
                var url = new Uri($"{Request.Scheme}://{Request.Host}");
                userRegister.CurrentUrl = url;
                await userService.RegisterNewUser(userRegister);

                return RedirectToAction("LogIn", "Account");
            }
            catch (AccountException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.FindByNameAsync(userLoginVM.Email);
                if (user != null)
                {
                    if (await this.userManager.IsEmailConfirmedAsync(user) == false)
                    {
                        ModelState.AddModelError(string.Empty, "You have not confirmed your Email!");
                        return View(userLoginVM);
                    }
                }

                var result = await this.signInManager.PasswordSignInAsync(userLoginVM.Email, userLoginVM.Password, userLoginVM.RememberMe, false);
                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    return Ok("Login is successful");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong email and/or password");
                }
            }
            return View(userLoginVM);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest();
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
