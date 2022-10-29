using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using WhatsHappening.BulkUpload.Data;

namespace WhatsHappening.BulkUpload.FromExcel
{
    public class ExcelBulkUploadService : IBulkUploadService
    {
        //http://stackoverflow.com/questions/15828/reading-excel-files-from-c-sharp

        public IEnumerable<EventLine> ReadEventLinesFromFile(string filename)
        {
            List<EventLine> list = new List<EventLine>();
            //filename = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), filename);
            var fileInfo = new FileInfo(filename);
            using (ExcelPackage excel = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets.First(p => p.Name == "Sheet1");
                var start = worksheet.Dimension.Start;
                var end = worksheet.Dimension.End;
                for (int rowNumber = start.Row + 1; rowNumber <= end.Row; rowNumber++)
                {
                    list.Add(new EventLine
                    {
                        EventId = worksheet.GetEventId(rowNumber),
                        Address = worksheet.GetAddress(rowNumber),
                        Categories = worksheet.GetCategoryList(rowNumber),
                        City = worksheet.GetCity(rowNumber),
                        Country = worksheet.GetCountry(rowNumber),
                        EventDates = worksheet.GetEventDateListAsDatetime(rowNumber),
                        Name = worksheet.GetName(rowNumber)
                    });
                }
            }
            return list;
        }
    }
}
