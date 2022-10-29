using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Web.Controllers.Api
{
    //[RoutePrefix("api/City")]
    public class CityController : ApiController
    {
        private readonly ILocationServices _locationServices;

        public CityController(ILocationServices locationServices)
        {
            _locationServices = locationServices;
        }

        public string Get()
        {
            return "teste";
        }

        // GET: api/City
        public IEnumerable<KeyValuePair<Guid, string>> Get(Guid countryId)
        {
            return _locationServices.GetCities(countryId).Select(p => new KeyValuePair<Guid, string>(p.Id, p.Name));
        }

    }
}
