using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Entities;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GUI.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager { get; set; }

        public SignInManager<AppUser> SignInManager { get; set; }

        public RoleManager<AppRole> RoleManager { get; set; }

        public ILogger<AccountController> Logger { get; set; }

        public CompleteGPSUtilityContext Context { get; set; }

        public IConfiguration Configuration { get; set; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager,
            ILogger<AccountController> logger, CompleteGPSUtilityContext context, IConfiguration configuration)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
            Logger = logger;
            Context = context;
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (await GetCurrentUserAsync() != null)
            {
                TempData["Message"] = "You are already Logged In!";
                return RedirectToAction("Index", "Home");
            }
            return View(new RegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var availableTokens = Configuration.GetSection("GUI:AvailableTokens").Get<string[]>();

            if (availableTokens.Contains(model.InvitationToken) == false)
            {
                Logger.LogWarning($"Used invalid InvitationToken:[{model.InvitationToken}] at account register.");
                ModelState.AddModelError("InvitationToken", "Invalid Token.");
                var t = Task.Run(async delegate
                {
                    await Task.Delay(5000);
                    return 42;
                });
                t.Wait();

                return View(model);
            }

            AppUser newUser = new AppUser { Email = model.Email, UserName = model.Email };
            var result = await UserManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                Logger.LogInformation($"New user has been registered. Email: [{model.Email}]");

                await SignInManager.SignInAsync(newUser, isPersistent: false);
                Logger.LogInformation($"User Logged In: [{model.Email}]");

                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (await GetCurrentUserAsync() != null)
            {
                TempData["Message"] = "You are already Logged In!";
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.Presistent, true);
            if (result.Succeeded)
            {
                Logger.LogInformation($"User Logged In: [{model.Email}]");
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var user = await GetCurrentUserAsync();
            await SignInManager.SignOutAsync();
            Logger.LogInformation($"Logout: [{user.Email}]");

            return RedirectToAction("Index", "Home");
        }
        private async Task<AppUser> GetCurrentUserAsync() => await UserManager.GetUserAsync(User);
    }
}