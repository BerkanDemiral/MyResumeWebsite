using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;

namespace MyCvProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository eduRepo = new EducationRepository();

        public ActionResult Index()
        {
            var values = eduRepo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(myEducations education)
        {
            eduRepo.TAdd(education);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            myEducations edu = eduRepo.Find(x => x.id == id);
            eduRepo.TDelete(edu);
            return RedirectToAction("Index");
        }

        public ActionResult GetEducations(int id)
        {
            myEducations edu = eduRepo.Find(x => x.id == id);
            return View(edu);
        }

        public ActionResult UpdateEducation(myEducations education)
        {
            myEducations edu = eduRepo.Find(x => x.id == education.id);
            edu.title = education.title;
            edu.subtitle1 = education.subtitle1;
            edu.subtitle2 = education.subtitle2;
            edu.GPA = education.GPA;
            edu.date = education.date;
            eduRepo.TUpdate(edu);
            return RedirectToAction("Index");

        }

    }
}