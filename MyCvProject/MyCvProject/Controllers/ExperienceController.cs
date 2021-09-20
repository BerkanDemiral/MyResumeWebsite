using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Repositories;
using MyCvProject.Models.Entity;
namespace MyCvProject.Controllers
{

    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository expRepo = new ExperienceRepository();

       
        public ActionResult Index()
        {
            var values = expRepo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(myExperiences experiences)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            expRepo.TAdd(experiences);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            myExperiences exp = expRepo.Find(x => x.id == id);
            expRepo.TDelete(exp);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id) // öncelikle üzerine tıklayan deneyim özelliklerinin listelenmesi gerekmektedir.
        {
            myExperiences exp = expRepo.Find(x => x.id == id);
            return View(exp);
        }


        [HttpPost]
        public ActionResult GetExperience(myExperiences experience) // öncelikle üzerine tıklayan deneyim özelliklerinin listelenmesi gerekmektedir.
        {
            myExperiences exp = expRepo.Find(x => x.id == experience.id);
            exp.title = experience.title;
            exp.subtitle = experience.subtitle;
            exp.description = experience.description;
            exp.date = experience.date;

            expRepo.TUpdate(exp);
            return RedirectToAction("Index");
        }
    }
}