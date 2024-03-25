using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my.website.Entities;

namespace my.website.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyWebsiteDbContext _websiteDbContext;

        public LoginController(MyWebsiteDbContext websiteDbContext)
        {
            _websiteDbContext = websiteDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return RedirectToAction("Index", "Login"); 

            var user = _websiteDbContext.Users.FirstOrDefault(u => u.Email == email);

            if (user == null || user.Password != password)
                return RedirectToAction("Index", "Login"); 

            return RedirectToAction("Index", "Home");
        }
    }
}
