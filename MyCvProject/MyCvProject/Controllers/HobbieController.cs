using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;
namespace MyCvProject.Controllers
{
    public class HobbieController : Controller
    {
        // GET: Hobbie
        HobbieRepository repo = new HobbieRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(myHobbies hobbie)
        {
            var h = repo.Find(x => x.id == 1);
            h.subtitle1 = hobbie.subtitle1;
            h.subtitle2 = hobbie.subtitle2;
            repo.TUpdate(h);
            return RedirectToAction("Index");

        }
        
        //[HttpGet]
        //public ActionResult AddHobbie()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddHobbie(myHobbies hobbie)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    repo.TAdd(hobbie);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult GetHobbie(int id)
        //{
        //    myHobbies hobbie = repo.Find(h => h.id == id);
        //    return View(hobbie);
        //}

        //public ActionResult UpdateHobbie(myHobbies hobbie)
        //{
        //    myHobbies h = repo.Find(x => x.id == hobbie.id);
        //    h.subtitle1 = hobbie.subtitle1;
        //    h.subtitle2 = hobbie.subtitle2;
        //    repo.TUpdate(h);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult DeleteHobbie(int id)
        //{
        //    myHobbies hobbie = repo.Find(h => h.id == id);
        //    repo.TDelete(hobbie);
        //    return RedirectToAction("Index");
            
        //}

    }
}