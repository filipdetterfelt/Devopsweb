using Microsoft.AspNetCore.Mvc;

namespace Devopsweb.Controllers
{
    public class SkillsController : Controller
    {
        public IActionResult TechnicalSkills()
        {
            return View();
        }
    }
}
