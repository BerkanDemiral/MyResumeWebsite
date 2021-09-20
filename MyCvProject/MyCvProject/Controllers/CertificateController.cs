using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;
namespace MyCvProject.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificateRepository repo = new CertificateRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(myCertifications certificate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.TAdd(certificate);
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteCertificate(int id)
        {
            myCertifications cer = repo.Find(x => x.id == id);
            repo.TDelete(cer);
            return RedirectToAction("Index");
        }

        public ActionResult GetCertificate(int id)
        {
            myCertifications cer = repo.Find(x => x.id == id);
            return View(cer);
        }

        public ActionResult UpdateCertificate(myCertifications certificate)
        {
            myCertifications cer = repo.Find(x => x.id == certificate.id);
            cer.description = certificate.description;
            repo.TUpdate(cer);

            return RedirectToAction("Index");
        }

    }
}