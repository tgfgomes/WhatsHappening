using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatsHappening.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            return PartialView("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}
