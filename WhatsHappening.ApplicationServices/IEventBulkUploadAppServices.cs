using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WhatsHappening.ApplicationServices
{
    public interface IEventBulkUploadAppServices
    {
        void ImportEventsFromFile(string filename);
        string SaveEventBulkUploadFile(HttpPostedFileBase file, string eventBulkUploadFolderMappedPath);
    }
}
