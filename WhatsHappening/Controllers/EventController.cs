using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Controllers
{
    public class EventController : ApiController
    {
        private ILocation _location;
        private ICategory _category;
        private IEventServices _eventServices;

        public EventController(ILocation location, ICategory category, IEventServices eventServices)
        {
            _location = location;
            _category = category;
            _eventServices = eventServices;
        }

        //... talvez as categorias devessem ser abertas para podermos gravar o que as pessoas estão a procurar
        //    ... serviço Que guarda as pesquisas feitas
        //public IEnumerable<IEvent> Get(DateTimeOffset? date, Guid? cityId, string city, Guid? categoryId)
        //{
        //    if (date.HasValue || cityId.HasValue || categoryId.HasValue)
        //    {
        //        IEnumerable<ILocation> possibleLocations = null;
        //        if (cityId.HasValue)
        //            return null;
        //        //_location.Load(cityId.Value, false);
        //        else if (!string.IsNullOrEmpty(city))
        //            _location.Services.Search(city);
        //        if (categoryId.HasValue)
        //            //_category.Load(categoryId.Value);
        //        return _eventServices.Search(date, _location, possibleLocations, _category);
        //    }
        //    return null;
        //}

    }
}
