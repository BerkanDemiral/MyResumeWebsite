using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
using MyCvProject.Repositories;

namespace MyCvProject.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia

        GenericRepositories<socialMedia> repo = new GenericRepositories<socialMedia>();
        public ActionResult Index()
        {
            var media = repo.List();
            return View(media);
        }

        [HttpGet]
        public ActionResult AddMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMedia(socialMedia s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        public ActionResult GetSocialMedia(int id)
        {
            socialMedia s = repo.Find(x => x.id == id);
            return View(s);
        }

        public ActionResult UpdateMedia(socialMedia media)
        {
            socialMedia s = repo.Find(x => x.id == media.id);
            s.social_media_name = media.social_media_name;
            s.icon = media.icon;
            s.link = media.link;
            s.status_ = true;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMedia(int id)
        {
            socialMedia s = repo.Find(x => x.id == id);
            s.status_ = false;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}