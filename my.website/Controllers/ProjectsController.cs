using Microsoft.AspNetCore.Mvc;
using my.website.Entities;

namespace my.website.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly MyWebsiteDbContext _context;

        public ProjectsController(MyWebsiteDbContext context)
        {
            _context = context;
        }
        public IActionResult CreateProjectIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Projects project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(); // Eğer model geçersizse, kullanıcıya aynı sayfayı göster
        }

    }
}
