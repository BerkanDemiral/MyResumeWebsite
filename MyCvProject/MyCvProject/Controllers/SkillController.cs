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

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddSkill(mySkills s)
        {
            if (ModelState.IsValid)
            {
                skillRepo.TAdd(s);
                ToastrService.AddToUserQueue(new Toastr(message: "Yeni Yetenek Eklendi. ", type: ToastrType.Success));
                return View();

            }
            else
            {

                ToastrService.AddToUserQueue(new Toastr(message: "Ekleme Yapılamadı ", type: ToastrType.Error));
                return View();
            }

            //return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            mySkills s = skillRepo.Find(x => x.id == id);
            skillRepo.TDelete(s);
            ToastrService.AddToUserQueue(new Toastr(message: "Yeni Yetenek Eklendi. ", type: ToastrType.Success));
            return RedirectToAction("Index");
        }

        public ActionResult GetSkill(int id)
        {
            mySkills s = skillRepo.Find(x => x.id == id);
            return View(s);
        }

        public ActionResult UpdateSkill(mySkills s)
        {
            mySkills skl = skillRepo.Find(x => x.id == s.id);
            skl.ratio = s.ratio;
            skl.skill_name = s.skill_name;
            skillRepo.TUpdate(skl);

            return RedirectToAction("Index");
        }
    }
}