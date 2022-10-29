using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatsHappening.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return RedirectPermanent("~/Index.html");
            //return View("_Layout");
            return PartialView("Index");
            //return RedirectPermanent("~/Views/Shared/_Layout.cshtml");
        }
    }
}
