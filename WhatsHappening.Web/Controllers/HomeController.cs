using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHappening.Domain.Services;
using WhatsHappening.Infrastructure;
using WhatsHappening.Web.Models.Event;
using WhatsHappening.Web.Models.Home;

namespace WhatsHappening.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<IResolverService> _resolverService;

        public HomeController(Lazy<IResolverService> resolverService)
        {
            _resolverService = resolverService;
        }

        public ActionResult Index()
        {
            IndexModel model = new IndexModel();
            model.EventSearchModel = new EventSearchModel();
            //ICategoryServices categoryServices = _resolverService.Value.Resolve<ICategoryServices>();
            //model.EventSearchModel.CategoryList = categoryServices.GetAll().Select(p => new SelectListItem
            //{
            //    Value = p.Id.ToString(),
            //    Text = p.Name
            //});
            List<SelectListItem> l1 = new List<SelectListItem>();
            l1.Add(new SelectListItem { Value = "1", Text = "one" });
            model.EventSearchModel.CategoryList = l1;
            return View(model);
        }
    }
}
