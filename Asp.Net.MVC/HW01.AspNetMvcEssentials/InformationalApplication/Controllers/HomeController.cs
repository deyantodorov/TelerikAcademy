﻿using System.Web.Mvc;

namespace InformationalApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}