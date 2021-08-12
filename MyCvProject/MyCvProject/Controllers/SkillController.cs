using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;
namespace MyCvProject.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillRepository skillRepo = new SkillRepository();
        public ActionResult Index()
        {
            var values = skillRepo.List();
            return View(values);
        }
    }
}