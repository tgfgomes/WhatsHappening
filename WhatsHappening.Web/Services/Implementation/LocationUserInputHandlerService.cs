using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsHappening.Web.Services.Implementation
{
    public class LocationUserInputHandlerService : ILocationUserInputHandlerService
    {
        public IEnumerable<string> GetLocationSearchTerms(string userSearchTerm)
        {
            if (!string.IsNullOrWhiteSpace(userSearchTerm))
            {
                var split = userSearchTerm.Split(',').ToList();
                split.ForEach(p => p.Trim());
                return split;
            }
            return new List<string>();
        }

    }
}