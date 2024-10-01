using Devopsweb.Data;
using Devopsweb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devopsweb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SkillsDbContext _skillsContext;

        public HomeController(ILogger<HomeController> logger, SkillsDbContext skillsContext)
        {
            _logger = logger;
            _skillsContext = skillsContext;
        }

        public IActionResult Index()
        {
            List<SkillsModel> skills = _skillsContext.Skills.ToList();
            return View(skills);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   
}
