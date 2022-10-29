using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Serialization
{
    public interface IEventRepository : IRepository
    {
        //void Load(IEventRW whEvent, Guid id);
        IEvent Get(Guid id);
        IEnumerable<IEventDate> GetEventDates(Guid eventId);
        ILocation GetEventLocation(Guid eventId);
        IEnumerable<ICategory> GetEventCategories(Guid eventId);
        //IEnumerable<IEvent> Search(DateTimeOffset? date, ILocation exactLocation, IEnumerable<ILocation> possibleLocations, ICategory category);
        IEnumerable<IEvent> Search(DateTimeOffset? date, ILocation location, IEnumerable<ICategory> categories);
        IEnumerable<IEvent> Search(DateTimeOffset? date, IEnumerable<ILocation> possibleLocations, IEnumerable<ICategory> categories);

        Guid AddNewEvent(IEvent whEvent);
    }
}
