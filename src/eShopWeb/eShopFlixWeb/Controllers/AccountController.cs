using eShopFlixWeb.Clients;
using eShopFlixWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShopFlixWeb.Controllers
{
    public class AccountController : Controller
    {
        private AuthenticationServiceClient authentication;

        public AccountController(AuthenticationServiceClient authentication)
        {
            this.authentication = authentication;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await authentication.LoginAsync(login);

                if (result.user.Roles.Contains("User"))
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
            }
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
