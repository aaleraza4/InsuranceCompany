using Data.Model;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCompany.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        internal readonly IServiceProvider _serviceProvider;

        public AccountController(SignInManager<ApplicationUser> signInManager, IServiceProvider serviceProvider)
        {
            _signInManager = signInManager;
            _serviceProvider = serviceProvider;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
            if(result.Succeeded)
            {
                return Json(new { Success = true});
            }
            else
            {
                return Json(new {Success=false});
            }
        }
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

        public async Task<bool> CheckEmailExists(string Email, int UserId)
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            bool IsExists = _userManager.Users.Where(x => x.Id != UserId && x.Email == Email).Any();
            return await Task.FromResult(!IsExists);
        }

    }
}
