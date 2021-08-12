﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCvProject.Models.Entity;
namespace MyCvProject.Controllers
{
    public class AboutMeController : Controller
    {
        // GET: AboutMe
        MyCvCareerEntities db = new MyCvCareerEntities();

        public ActionResult Index()
        {
            var values = db.aboutMe.ToList();

            return View(values);
        }
    }
}