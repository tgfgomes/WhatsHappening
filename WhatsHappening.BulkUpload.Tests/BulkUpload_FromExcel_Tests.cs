using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatsHappening.BulkUpload.FromExcel;
using WhatsHappening.BulkUpload.Tests.Unity;

namespace WhatsHappening.BulkUpload.Tests
{
    [TestClass]
    public class BulkUpload_FromExcel_Tests
    {
        //private static IUnityContainer _unityContainer;

        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //    _unityContainer = UnityConfig.GetConfiguredContainer();
        //}


        [TestMethod]
        public void ExcelBulkUploadService_Test()
        {
            ExcelBulkUploadService svc = new ExcelBulkUploadService();
            svc.ReadEventLinesFromFile(@"Files\WhatsHappening_bulk_upload_file_tests1.xlsx");
        }
    }
}
