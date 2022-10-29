using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Serialization;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Implementation.Services
{
    public class EventServices : IEventServices
    {
        private readonly Lazy<IEventsUnitOfWork> _eventsUnitOfWork;
        
        public EventServices(Lazy<IEventsUnitOfWork> eventsUnitOfWork)
        {
            _eventsUnitOfWork = eventsUnitOfWork;
        }

        public IEnumerable<IEventDate> GetEventDates(Guid eventId)
        {
            return _eventsUnitOfWork.Value.EventRepository.GetEventDates(eventId);
        }

        public ILocation GetEventLocation(Guid eventId)
        {
            return _eventsUnitOfWork.Value.EventRepository.GetEventLocation(eventId);
        }

        public Guid CreateEvent(IEvent whevent)
        {
            ILocation eventLocation = whevent.GetEventLocation();
            //TODO: add new categories first
            if (eventLocation.City.Id == default(Guid) && !string.IsNullOrEmpty(eventLocation.City.Name))
            {
                _eventsUnitOfWork.Value.CityRepository.AddNewCity(eventLocation.City);
            }
            Guid newEventId = _eventsUnitOfWork.Value.EventRepository.AddNewEvent(whevent);
            _eventsUnitOfWork.Value.Commit();
            //TODO: Change id property or load again using newEventId? return newEventId?
            (whevent as WhatsHappening.Domain.Models.RW.IEventRW).Id = newEventId;
            return newEventId;
        }


        public IEnumerable<ICategory> GetEventCategories(Guid eventId)
        {
            return _eventsUnitOfWork.Value.EventRepository.GetEventCategories(eventId);
        }

        public IEvent GetEvent(Guid eventId)
        {
            return _eventsUnitOfWork.Value.EventRepository.Get(eventId);
        }



        public IEnumerable<IEvent> Search(DateTimeOffset? date, IEnumerable<string> locationSearchTerms, IEnumerable<ICategory> categories)
        {
            var possibleLocations = _eventsUnitOfWork.Value.LocationRepository.Search(locationSearchTerms);
            return _eventsUnitOfWork.Value.EventRepository.Search(date, possibleLocations, categories);
        }

        public IEnumerable<IEvent> Search(DateTimeOffset? date, ILocation exactLocation, IEnumerable<ILocation> possibleLocations, ICategory category)
        {
            throw new NotImplementedException();
            //return _eventsUnitOfWork.Value.EventRepository.Search(date, exactLocation, possibleLocations, category);
        }



    }
}
