using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;
namespace MyCvProject.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: AdminController
        GenericRepositories<members> repo = new GenericRepositories<members>();
        MyCvCareerEntities2 db = new MyCvCareerEntities2();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(members m)
        {
            var isThereUser = db.members.Where(x => x.username == m.username);

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (isThereUser !=null){
                
            }

            repo.TAdd(m);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            members admin = repo.Find(x => x.id == id);
            if (admin != null && repo.List().Count() == 1)
            {
                
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                repo.TDelete(admin);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult GetAdmin(int id) // öncelikle üzerine tıklayan deneyim özelliklerinin listelenmesi gerekmektedir.
        {
            members admin = repo.Find(x => x.id == id);
            return View(admin);
        }


        [HttpPost]
        public ActionResult GetAdmin(members a) // öncelikle üzerine tıklayan deneyim özelliklerinin listelenmesi gerekmektedir.
        {
            members admin = repo.Find(x => x.id == a.id);
            admin.username = a.username;
            admin.password = a.password;


            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}