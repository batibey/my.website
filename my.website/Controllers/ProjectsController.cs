using Microsoft.AspNetCore.Mvc;
using my.website.Data;
using my.website.Entities;
using my.website.Services.Abstract;
using Serilog;

namespace my.website.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly MyWebsiteDbContext _context;
        private readonly IEmailService _emailService;

        public ProjectsController(MyWebsiteDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public IActionResult CreateProjectIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Projects project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();

                string? toMail = "TO_MAIL";
                string subject = "Information";
                string body = "Your project has been successfully created.";

                await _emailService.SendMailAsync(toMail, subject, body);
                Log.Information($" Project name : {project.ProjectName} Author: {project.Author} added.");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index","Home"); 
        }

    }
}
