using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Web.Models.CommonModels;

namespace WhatsHappening.Web.Models.Event
{
    public class SearchResultsModel
    {
        public EventSearchModel EventSearchData { get; set; }
        public IEnumerable<EventDetailModel> EventList { get; set; }
        public PaginationModel Pagination { get; set; }
    }
}
