using Microsoft.AspNetCore.Mvc;

namespace eShopFlixWeb.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
