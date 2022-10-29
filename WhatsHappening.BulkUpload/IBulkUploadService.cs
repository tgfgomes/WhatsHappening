using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.BulkUpload.Data;

namespace WhatsHappening.BulkUpload
{
    public interface IBulkUploadService
    {
        IEnumerable<EventLine> ReadEventLinesFromFile(string filename);
    }
}
