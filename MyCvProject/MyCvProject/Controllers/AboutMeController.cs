using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;
namespace MyCvProject.Controllers
{
    public class AboutMeController : Controller
    {
        // GET: AboutMe
        AboutMeRepository repo = new AboutMeRepository();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        //[HttpGet]
        //public ActionResult AddAbout()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddAbout(aboutMe about)
        //{
        //    repo.TAdd(about);
        //    return RedirectToAction("Index");
        //}

        public ActionResult DeleteAbout(int id)
        {
            aboutMe about = repo.Find(x => x.Id == id);
            repo.TDelete(about);
            return RedirectToAction("Index");
        }

        public ActionResult GetAbout(int id)
        {
            aboutMe about = repo.Find(x => x.Id == id);
            return View(about);
        }

        public ActionResult UpdateAbout(aboutMe about)
        {
            aboutMe a = repo.Find(x => x.Id == about.Id);
            a.first_name = about.first_name;
            a.last_name = about.last_name;
            a.phone = about.phone;
            a.photo = about.photo;
            a.email = about.email;
            a.address = about.address;
            repo.TUpdate(a);
            return RedirectToAction("Index");
        }

    }
}