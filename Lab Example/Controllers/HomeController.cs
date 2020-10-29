using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Homepage";
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Have any concerns or feedback? \n We would love to hear it.";

            return View();
        }
    }
}