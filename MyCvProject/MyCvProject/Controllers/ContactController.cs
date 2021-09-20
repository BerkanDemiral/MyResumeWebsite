using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;

namespace MyCvProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository repo = new ContactRepository();


        public ActionResult Index()
        {
            var values = repo.orderByDesc();
            return View(values);
        }

        public ActionResult SendMessage(int id)
        {
            var target = repo.Find(x => x.id == id);
            ViewBag.email = target.email;
            ViewBag.name = target.name;
            ViewBag.subject = target.subject;
            return View();
        }

        //[HttpPost]
        //public ActionResult SendMessage(int id)
        //{
        //    var target = repo.Find(x => x.id == id);
        //    ViewBag.mail = target.email;
        //    ViewBag.name = target.name;
        //    return RedirectToAction("Index", "Contact");
        //}
    }
}