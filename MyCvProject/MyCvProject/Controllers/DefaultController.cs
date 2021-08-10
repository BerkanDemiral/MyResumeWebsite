using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
namespace MyCvProject.Controllers

    // mvc'de tek sayfada sadece 1 tablo kullanılabilir. Bunun önlenebilmesi için "Enumerable yapısı veya PartialViewResult" yapısı kullanılabilir.
    // partialview yapısında, farklı tablo içeriği için farklı fonksiyon ve sayfa oluşturulur. Ve bu sayfada farklı tablo içeriğine ait html yapısı girilir.
    // ardından ana html yapısında sıralamalar ayarlanarak sayfa düzeni oturtulmuş olur.  

{
    public class DefaultController : Controller
    {
        // GET: Default
        MyCvCareerEntities db = new MyCvCareerEntities();
        public ActionResult Index()
        {
            var values = db.aboutMe.ToList();
            return View(values);
        }

        public PartialViewResult Experiences()
        {
            var values = db.myExperiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult Educations()
        {
            var values = db.myEducations.ToList();
            return PartialView(values);
        }

        public PartialViewResult Skills()
        {
            var values = db.mySkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult Hobbies()
        {
            var values = db.myHobbies.ToList();
            return PartialView(values);
        }

        public PartialViewResult Certifications()
        {
            var values = db.myCertifications.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(contact cnt)
        {
            cnt.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.contact.Add(cnt);
            db.SaveChanges();
            return PartialView();
        }
    }
}