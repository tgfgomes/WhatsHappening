using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Data.EF;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Serialization.Implementation
{
    public class EventRepository : RepositoryBase, IEventRepository
    {
        public EventRepository(IResolverService resolverService)
            : base(resolverService)
        {
        }

        public IEvent Get(Guid id)
        {
            var efEvent = DbContext.Event.Single(p => p.id == id);
            return EfToIEvent(efEvent);
        }

        public IEnumerable<IEvent> Search(DateTimeOffset? date, IEnumerable<ILocation> possibleLocations, IEnumerable<ICategory> categories)
        {
            if (date.HasValue || possibleLocations != null || (categories != null && categories.Count() > 0))
            {
                var q = DbContext.Event.AsQueryable();
                if (date.HasValue)
                {
                    var dt = date.Value.Date;
                    q = q.Where(p => p.EventDates.Any(ed => System.Data.Entity.DbFunctions.TruncateTime(ed.date) == dt));
                }
                //if (location != null && location.City.Id != Guid.Empty)
                //    q = q.Where(p => p.City.id == location.City.Id);
                if (possibleLocations != null)
                    q = FilterByLocations(q, possibleLocations);
                if (categories != null && categories.Count() > 0)
                {
                    var catIds = categories.Where(p => p != null).Select(p => p.Id);
                    q = q.Where(p => p.Category.Any(c => catIds.Contains(c.id)));
                }
                foreach (var e in q)
                {
                    yield return EfToIEvent(e);
                }
            }
        }


        public IEnumerable<IEvent> Search(DateTimeOffset? date, ILocation location, IEnumerable<ICategory> categories)
        {
            return Search(date, new List<ILocation> { location }, categories);
            //if (date.HasValue || location != null || (categories != null && categories.Count() > 0))
            //{
            //    var q = DbContext.Event.AsQueryable();
            //    if (date.HasValue)
            //        q = q.Where(p => p.EventDates.Where(ed => ed.date.Date == date.Value.Date).Any());
            //    //if (location != null && location.City.Id != Guid.Empty)
            //    //    q = q.Where(p => p.City.id == location.City.Id);
            //    if (location != null)
            //        q = FilterByLocations(q, new List<ILocation> { location });
            //    if (categories != null && categories.Count() > 0)
            //    {
            //        var catIds = categories.Select(p => p.Id);
            //        q = q.Where(p => p.Category.Any(c => catIds.Contains(c.id)));
            //    }
            //    foreach (var e in q)
            //    {
            //        yield return EfToIEvent(e);
            //    }
            //}
            //yield return null;
        }

        private IQueryable<Event> FilterByLocations(IQueryable<Event> eventQuery, IEnumerable<ILocation> locations)
        {
            var cityIdList = locations.Select(p => p.City.Id).ToList();
            return eventQuery.Where(p => cityIdList.Contains(p.City.id));
        }

        //public IEnumerable<IEvent> Search(DateTimeOffset? date, ILocation exactLocation, IEnumerable<ILocation> possibleLocations, ICategory category)
        //{
        //    if (date.HasValue || (exactLocation != null && exactLocation.City.Id != Guid.Empty) || (category != null && category.Id != Guid.Empty))
        //    {
        //        var q = DbContext.Event.AsQueryable();
        //        if (date.HasValue)
        //            q = q.Where(p => p.EventDates.Where(ed => ed.date.Date == date.Value.Date).Any());
        //        if (exactLocation != null && exactLocation.City.Id != Guid.Empty)
        //            q = q.Where(p => p.City.id == exactLocation.City.Id);
        //        else if (possibleLocations != null && possibleLocations.Count() > 0)
        //            q = q.Where(p => possibleLocations.Where(l => l.City.Id == p.cityId).Count() > 0);
        //        if (category != null && category.Id != Guid.Empty)
        //            q = q.Where(p => p.Category.Where(c => c.id == category.Id).Any());
        //        foreach (var e in q)
        //        {
        //            yield return EfToIEvent(e);
        //        }
        //    }
        //    yield return null;
        //}

        private IEvent EfToIEvent(Data.EF.Event efEvent)
        {
            IEventRW whEvent = _resolverService.Resolve<IEventRW>();
            whEvent.Id = efEvent.id;
            whEvent.Name = efEvent.name;
            whEvent.Address = efEvent.address;
            whEvent.CreationDate = efEvent.creationDate;
            whEvent.LastUpdateDate = efEvent.lastUpdateDate;
            return whEvent;
        }

        public IEnumerable<IEventDate> GetEventDates(Guid eventId)
        {
            var q = DbContext.EventDates.Where(p => p.eventId == eventId);
            foreach (var ed in q)
            {
                IEventDateRW eventDate = _resolverService.Resolve<IEventDateRW>();
                eventDate.Id = ed.id;
                eventDate.Date = ed.date;
                yield return eventDate;
            }
        }


        public Guid AddNewEvent(IEvent whEvent)
        {
            Data.EF.Event efEvent = new Data.EF.Event();
            efEvent.id = Guid.NewGuid();
            IEventToEf(whEvent, efEvent);
            DbContext.Event.Add(efEvent);
            return efEvent.id;
        }


        private Data.EF.Event IEventToEf(IEvent whEvent, Data.EF.Event efEvent)
        {
            efEvent.name = whEvent.Name;
            efEvent.address = whEvent.Address;
            foreach (var eventCategory in whEvent.GetEventCategories())
            {
                efEvent.Category.Add(DbContext.Category.Find(eventCategory.Id));
            }
            //efEvent.Category = categoryList;
            //var catIds = whEvent.GetEventCategories().Select(c => c.Id).ToList();
            //efEvent.Category = DbContext.Category.Where(p => catIds.Contains(p.id)).ToList();
            //efEvent.Category = DbContext.Category.Local
            Guid cityId = whEvent.GetEventLocation().City.Id;
            //efEvent.City = DbContext.City.Single(p => p.id == cityId);
            //efEvent.cityId = cityId;
            efEvent.City = DbContext.City.Find(cityId);
            //efEvent.gpsLocation
            foreach (var ed in whEvent.GetEventDates())
            {
                efEvent.EventDates.Add(new Data.EF.EventDates
                {
                    id = Guid.NewGuid(),
                    date = ed.Date,
                    Event = efEvent
                });
            }
            efEvent.creationDate = DateTime.Now;
            efEvent.lastUpdateDate = efEvent.creationDate;
            return efEvent;
        }


        public IEnumerable<ICategory> GetEventCategories(Guid eventId)
        {
            var q = DbContext.Event.Single(p => p.id == eventId).Category;
            foreach (var c in q)
            {
                ICategoryRW eventCategory = _resolverService.Resolve<ICategoryRW>();
                eventCategory.Id = c.id;
                eventCategory.Name = c.name;
                yield return eventCategory;
            }
        }

        public ILocation GetEventLocation(Guid eventId)
        {
            var e = DbContext.Event.Single(p => p.id == eventId);
            ILocationRW location = _resolverService.Resolve<ILocationRW>();
            ICityRW city = _resolverService.Resolve<ICityRW>();
            city.Id = e.City.id;
            city.Name = e.City.name;
            location.Set(city);
            return location;
        }





    }
}
