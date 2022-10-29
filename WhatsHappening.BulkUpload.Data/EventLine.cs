using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.BulkUpload.Data
{
    public class EventLine
    {
        public Guid? EventId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<string> Categories { get; set; }
        public List<DateTime> EventDates { get; set; }
    }
}
