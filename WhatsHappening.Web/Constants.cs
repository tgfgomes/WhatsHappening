using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WhatsHappening.Web
{
    public class Constants
    {
        public const string UploadFolderPath = "~/Upload";
        public const string EventBulkUploadFolder = "EventBulkUpload";
        public static string EventBulkUploadFolderPath { get { return Path.Combine(UploadFolderPath, EventBulkUploadFolder); } }
    }
}