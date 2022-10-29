using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;

namespace WhatsHappening.Domain.Services
{
    public interface IEventServices
    {
        IEvent GetEvent(Guid eventId);

        IEnumerable<IEventDate> GetEventDates(Guid eventId);
        ILocation GetEventLocation(Guid eventId);
        IEnumerable<ICategory> GetEventCategories(Guid eventId);

        Guid CreateEvent(IEvent whevent);


        //IEnumerable<IEvent> Search(DateTimeOffset? date, ILocation exactLocation, IEnumerable<ILocation> possibleLocations, ICategory category);
        IEnumerable<IEvent> Search(DateTimeOffset? date, IEnumerable<string> locations, IEnumerable<ICategory> categories);

    }
}
