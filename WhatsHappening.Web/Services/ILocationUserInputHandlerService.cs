using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsHappening.Web.Services
{
    public interface ILocationUserInputHandlerService
    {
        IEnumerable<string> GetLocationSearchTerms(string userSearchTerm);
    }
}