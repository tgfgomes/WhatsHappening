using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Models
{   
    public interface IEvent
    {
        Guid Id { get; }
        string Name { get; set; }
        string Address { get; set; }
        //System.Data.Entity.Spatial.DbGeography gpsLocation { get; set; }
        DateTimeOffset CreationDate { get; }
        DateTimeOffset LastUpdateDate { get; }

        void SetEventLocation(ILocation location);
        ILocation GetEventLocation();

        void AddEventDate(IEventDate eventDate);
        IEnumerable<IEventDate> GetEventDates();

        void AddEventCategory(ICategory categoty);
        IEnumerable<ICategory> GetEventCategories();

        IEventServices Services { get; }
    }
}
