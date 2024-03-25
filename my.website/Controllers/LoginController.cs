using Microsoft.AspNetCore.Mvc;

namespace my.website.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return RedirectToAction("Index","Home");
        }
    }
}
