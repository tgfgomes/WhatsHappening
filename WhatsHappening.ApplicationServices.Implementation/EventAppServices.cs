using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Services;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.ApplicationServices.Implementation
{
    public class EventAppServices : IEventAppServices
    {
        private readonly Lazy<IResolverService> _resolverService;

        public EventAppServices(Lazy<IResolverService> resolverService)
        {
            _resolverService = resolverService;
        }

        public IEvent CreateEvent(string name, string address, ILocation location, DateTime eventDate, IEnumerable<ICategory> selectedCategoryList)
        {
            IEvent whevent = _resolverService.Value.Resolve<IEvent>();
            whevent.Name = name;
            whevent.Address = address;
            whevent.SetEventLocation(location);
            List<IEventDate> eventDates = new List<IEventDate>();
            IEventDate eventDateDm = _resolverService.Value.Resolve<IEventDate>();
            eventDateDm.Date = eventDate;
            whevent.AddEventDate(eventDateDm);
            ICategoryServices categoryServices = _resolverService.Value.Resolve<ICategoryServices>();
            foreach (var selectedCategory in selectedCategoryList)
            {
                whevent.AddEventCategory(selectedCategory);
            }
            IEventServices eventServices = _resolverService.Value.Resolve<IEventServices>();
            eventServices.CreateEvent(whevent);
            return whevent;
        }


        public IEvent CreateEvent(string name, string address, Guid selectedCityId, DateTime eventDate, IEnumerable<Guid> selectedCategoryIdList)
        {
            ILocation location = _resolverService.Value.Resolve<ILocation>();
            location.Set(location.Services.GetCity(selectedCityId));
            ICategoryServices categoryServices = _resolverService.Value.Resolve<ICategoryServices>();
            List<ICategory> categotyList = new List<ICategory>();
            foreach (var selectedCategoryId in selectedCategoryIdList)
            {
                categotyList.Add(categoryServices.Get(selectedCategoryId));
            }
            return CreateEvent(name, address, location, eventDate, categotyList);
        }


        //public IEvent CreateEvent(string name, string address, Guid selectedCityId, DateTime eventDate, IEnumerable<Guid> selectedCategoryIdList)
        //{
        //    ILocation location = _resolverService.Value.Resolve<ILocation>();
        //    IEvent whevent = _resolverService.Value.Resolve<IEvent>();
        //    whevent.Name = name;
        //    whevent.Address = address;
        //    location.Set(location.Services.GetCity(selectedCityId));
        //    whevent.SetEventLocation(location);
        //    List<IEventDate> eventDates = new List<IEventDate>();
        //    IEventDate eventDateDm = _resolverService.Value.Resolve<IEventDate>();
        //    eventDateDm.Date = eventDate;
        //    whevent.AddEventDate(eventDateDm);
        //    ICategoryServices categoryServices = _resolverService.Value.Resolve<ICategoryServices>();
        //    foreach (var selectedCategoryId in selectedCategoryIdList)
        //    {
        //        whevent.AddEventCategory(categoryServices.Get(selectedCategoryId));
        //    }
        //    IEventServices eventServices = _resolverService.Value.Resolve<IEventServices>();
        //    eventServices.CreateEvent(whevent);
        //    return whevent;
        //}


    }
}
