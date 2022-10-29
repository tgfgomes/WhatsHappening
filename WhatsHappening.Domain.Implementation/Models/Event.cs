using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Domain.Services;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Implementation.Models
{
    public class Event : IEventRW
    {
        private Lazy<IResolverService> _resolverSerice;
        private ILocation _eventLocation;
        private List<IEventDate> _eventDates;
        private List<ICategory> _eventCategories;

        public Event(Lazy<IResolverService> resolverService, IEventServices eventServices)
        {
            _resolverSerice = resolverService;
            Services = eventServices;
        }


        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //System.Data.Entity.Spatial.DbGeography gpsLocation { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset LastUpdateDate { get; set; }
        //public ILocation Location { get; set; }
        //public IEnumerable<IEventDate> EventDates { get; set; }
        //public IEnumerable<ICategory> Categories { get; set; }
        public IEventServices Services { get; set; }


        public void SetEventLocation(ILocation location)
        {
            _eventLocation = location;
        }

        public ILocation GetEventLocation()
        {
            if (_eventLocation == null)
            {
                _eventLocation = Services.GetEventLocation(Id);
            }
            return _eventLocation;
        }

        public void AddEventDate(IEventDate eventDate)
        {
            LoadEventDatesIfNotLoaded();
            _eventDates.Add(eventDate);
        }

        public IEnumerable<IEventDate> GetEventDates()
        {
            LoadEventDatesIfNotLoaded();
            return _eventDates;
        }

        public void LoadEventDatesIfNotLoaded()
        {
            if (Id == default(Guid) && _eventDates == null)
            {
                _eventDates = new List<IEventDate>();
            }
            else if (_eventDates == null)
            {
                _eventDates = Services.GetEventDates(Id).ToList();
            }
        }

        public void AddEventCategory(ICategory categoty)
        {
            LoadCategoriesIfNotLoaded();
            _eventCategories.Add(categoty);
        }

        public IEnumerable<ICategory> GetEventCategories()
        {
            LoadCategoriesIfNotLoaded();
            return _eventCategories;
        }

        public void LoadCategoriesIfNotLoaded()
        {
            if (Id == default(Guid) && _eventCategories == null)
            {
                _eventCategories = new List<ICategory>();
            }
            else if (_eventCategories == null)
            {
                _eventCategories = Services.GetEventCategories(Id).ToList();
            }
        }


    }
}
