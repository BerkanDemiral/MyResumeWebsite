using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyCvProject.Models.Entity;
namespace MyCvProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyCvCareerEntities2 db = new MyCvCareerEntities2();
        public ActionResult Index(members m)
        {
            var info = db.members.FirstOrDefault(x => x.username == m.username && x.password == m.password);
            if (info != null) // eğer yukarıdaki koşul sonucunda bir değer döndüyse, yani 2 ifade de doğruysa;
            {
                FormsAuthentication.SetAuthCookie(info.username, false);
                Session["username"] = info.username.ToString(); // tutulacak bilgi
                return RedirectToAction("Index", "AboutMe/Index/"); // nereye yönlendirecek
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // abandon: bırakmak, terk etmek...
            return RedirectToAction("Index", "Login/Index/");
        }
    }
}