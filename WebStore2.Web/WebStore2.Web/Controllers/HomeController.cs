﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore2.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var wcc = new WebStore2Service.WebStoreServiceClient())
            {
                string result = wcc.GetData(29);
                ViewBag.Message = result;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}