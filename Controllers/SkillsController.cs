using Devopsweb.Data;
using Devopsweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devopsweb.Controllers
{
    public class SkillsController : Controller
    {
        private readonly SkillsDbContext _skillsContext;

        public SkillsController(SkillsDbContext skillsContext) 
        {
            _skillsContext = skillsContext;
        }

        public IActionResult TechnicalSkills()
        {

            List<SkillsModel> skills = _skillsContext.Skills.ToList();

           
            return View(skills);
        }
    }
}
