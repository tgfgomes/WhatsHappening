using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Web.Controllers.Api
{
    public class EventController : ApiController
    {
        private readonly IEventServices _eventServices;

        public EventController(IEventServices eventServices)
        {
            _eventServices = eventServices;
        }

        //public IEnumerable<IEvent> GetAll()
        //{
        //    return _eventServices.Search
        //}

    }
}
