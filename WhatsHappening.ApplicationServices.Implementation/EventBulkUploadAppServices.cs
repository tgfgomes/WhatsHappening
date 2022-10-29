using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WhatsHappening.BulkUpload;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.ApplicationServices.Implementation
{
    public class EventBulkUploadAppServices : IEventBulkUploadAppServices
    {
        private readonly Lazy<IBulkUploadService> _bulkUploadService;
        private readonly Lazy<ICategoryServices> _categoryServices;
        private readonly Lazy<ILocationServices> _locationServices;
        private readonly Lazy<IEventAppServices> _eventAppServices;


        public EventBulkUploadAppServices(Lazy<IBulkUploadService> bulkUploadService, Lazy<ICategoryServices> categoryServices, Lazy<ILocationServices> locationServices, Lazy<IEventAppServices> eventAppServices)
        {
            _bulkUploadService = bulkUploadService;
            _categoryServices = categoryServices;
            _locationServices = locationServices;
            _eventAppServices = eventAppServices;
        }


        public string SaveEventBulkUploadFile(HttpPostedFileBase file, string eventBulkUploadFolderMappedPath)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                //var directory = HttpServerUtility.Server.MapPath(Constants.EventBulkUploadFolderPath);
                if (!Directory.Exists(eventBulkUploadFolderMappedPath))
                {
                    Directory.CreateDirectory(eventBulkUploadFolderMappedPath);
                }
                fileName = string.Format("[{0}]{1}", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff"), fileName);
                var pathAndFilname = Path.Combine(eventBulkUploadFolderMappedPath, fileName);
                file.SaveAs(pathAndFilname);
                return pathAndFilname;
            }
            return null;
        }


        public void ImportEventsFromFile(string filename)
        {
            foreach (var eventLine in _bulkUploadService.Value.ReadEventLinesFromFile(filename))
            {
                var location = _locationServices.Value.FindLocationOrCreate(eventLine.City, eventLine.Country);
                var categoryList = new List<ICategory>();
                //foreach (var categoryName in eventLine.Categories.Where(p => cachedCategories.Select(c => !c.Name.ToLower()).Contains(p.ToLower())).ToList())
                foreach (var categoryName in eventLine.Categories)
                {
                    var category = _categoryServices.Value.FindOrAddNew(categoryName);
                    categoryList.Add(category);
                }
                //TODO: implement multidates
                var whevent = _eventAppServices.Value.CreateEvent(eventLine.Name, eventLine.Address, location, eventLine.EventDates.First(), categoryList);
                //var whevent = _eventAppServices.Value.CreateEvent(eventLine.Name, eventLine.Address, location.City.Id, eventLine.EventDates.First(), categoryList.Select(p => p.Id));
            }
        }


    }
}

