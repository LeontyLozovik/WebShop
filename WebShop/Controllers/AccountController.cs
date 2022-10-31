using Identity.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using WebShop.Filters;
using WebShop.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IMemoryCache _memoryCache;
        private ILogger<AccountController> _logger;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            IMemoryCache memoryCache, ILogger<AccountController> logger)
        { 
            _userManager = userManager;
            _signInManager = signInManager;
            _memoryCache = memoryCache;
            _logger = logger;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModel))]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var hasError = HttpContext.Items["error"] as Boolean?;
            if (hasError.HasValue)
            {
                var user = new AppUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                _logger.Log(LogLevel.Information, "Success creating new user");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Courier");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Account");
                    _logger.Log(LogLevel.Information, "Success registration new user");
                }
            }         

            return View(model);
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModel))]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            var hasError = HttpContext.Items["error"] as Boolean?;
            if (hasError.HasValue)
            {
                var user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    _logger.Log(LogLevel.Information, "Success finding user");
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    _logger.Log(LogLevel.Information, "Success login");
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(loginModel.ReturnUrl) && Url.IsLocalUrl(loginModel.ReturnUrl))
                        {
                            return Redirect(loginModel.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("AllOrders", "Order");
                        }
                    }
                    _logger.Log(LogLevel.Warning, "InvalidPassword");
                }
                else
                {
                    _logger.Log(LogLevel.Warning, "No user with this UserName");
                    return RedirectToAction("Register");
                }
            }    

            return View(loginModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.Log(LogLevel.Information, "Success logout");
            return RedirectToAction("Login", "Account");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
