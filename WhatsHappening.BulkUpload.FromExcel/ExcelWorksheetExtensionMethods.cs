using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.BulkUpload.FromExcel
{
    public static class ExcelWorksheetExtensionMethods
    {
        private const char Separator = ';';

        public static Guid? GetEventId(this ExcelWorksheet worksheet, int rowNumber)
        {
            return worksheet.GetValue<Guid?>(rowNumber, (int)WhColumnEnum.EventId);
        }

        public static string GetName(this ExcelWorksheet worksheet, int rowNumber)
        {
            return worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.EventName);
        }

        public static string GetAddress(this ExcelWorksheet worksheet, int rowNumber)
        {
            return worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.Address);
        }

        public static string GetCity(this ExcelWorksheet worksheet, int rowNumber)
        {
            return worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.City);
        }

        public static string GetCountry(this ExcelWorksheet worksheet, int rowNumber)
        {
            return worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.Country);
        }

        public static string GetCategories(this ExcelWorksheet worksheet, int rowNumber)
        {
            return worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.Categories);
        }

        public static List<string> GetCategoryList(this ExcelWorksheet worksheet, int rowNumber)
        {
            List<string> list = new List<string>();
            string c = worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.Categories);
            list = c.Split(ExcelWorksheetExtensionMethods.Separator).ToList();
            return RemoveEmptyItemsFromList(list);
        }

        public static string GetEventDates(this ExcelWorksheet worksheet, int rowNumber)
        {
            return worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.EventDates);
        }

        public static List<string> GetEventDateList(this ExcelWorksheet worksheet, int rowNumber)
        {
            List<string> list = new List<string>();
            string dt = worksheet.GetValue<string>(rowNumber, (int)WhColumnEnum.EventDates);
            list = dt.Split(ExcelWorksheetExtensionMethods.Separator).ToList();
            return RemoveEmptyItemsFromList(list);
            //return list.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
        }

        public static List<DateTime> GetEventDateListAsDatetime(this ExcelWorksheet worksheet, int rowNumber)
        {
            List<DateTime> list = new List<DateTime>();
            foreach (var eventDateString in GetEventDateList(worksheet, rowNumber))
            {
                list.Add(DateTime.Parse(eventDateString));
            }
            return list;
        }


        private static List<T> RemoveEmptyItemsFromList<T>(IEnumerable<T> list)
        {
            return list.Where(p => !string.IsNullOrWhiteSpace(p.ToString())).ToList();
        }


    }
}
