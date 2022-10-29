using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHappening.ApplicationServices;
using WhatsHappening.Infrastructure;
//using WhatsHappening.Web.Areas.Backoffice.Models;

namespace WhatsHappening.Web.Areas.Backoffice.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize()]
    public class EventBulkUploadController : Controller
    {
        private readonly Lazy<IResolverService> _resolverService;

        public EventBulkUploadController(Lazy<IResolverService> resolverService)
        {
            _resolverService = resolverService;

            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            //if (User.IsInRole("Admin"))
            //{
            //    //Update method etc....
            //}

            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(EventBulkUploadModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IEventBulkUploadAppServices eventBulkUploadAppServices = _resolverService.Value.Resolve<IEventBulkUploadAppServices>();
        //        //eventBulkUploadAppServices.ImportEventsFromFile(model.file);


        //        //return RedirectToAction("Detail", new { id = whevent.Id });
        //        return View(model);
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(file.FileName);
                //var directory = Server.MapPath(Constants.EventBulkUploadFolderPath);
                //if (!Directory.Exists(directory))
                //{
                //    Directory.CreateDirectory(directory);
                //}
                //var path = Path.Combine(directory, fileName);
                //file.SaveAs(path);
                IEventBulkUploadAppServices eventBulkUploadAppServices = _resolverService.Value.Resolve<IEventBulkUploadAppServices>();
                var filenameAndPath = eventBulkUploadAppServices.SaveEventBulkUploadFile(file, Server.MapPath(Constants.EventBulkUploadFolderPath));
                eventBulkUploadAppServices.ImportEventsFromFile(filenameAndPath);
            }

            return RedirectToAction("Index");
        }



    }
}