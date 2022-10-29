using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Controllers
{
    public class LocationController : ApiController
    {
        private ILocationServices _locationServices;

        public LocationController(ILocationServices locationServices)
        {
            _locationServices = locationServices;
        }

        //// GET api/Location
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/Location/5
        public IEnumerable<KeyValuePair<Guid, string>> Get(string searchTerm)
        {
            //List<KeyValuePair<Guid, string>> l = new List<KeyValuePair<Guid, string>>();
            //foreach (var location in _locationServices.SearchLocations(searchTerm))
            //{
            //    l.Add(new KeyValuePair<Guid, string>(location.CityId, location.Name));
            //}
            //return l;
            //foreach (var location in _locationServices.Search(searchTerm))
            //{
            //    yield return new KeyValuePair<Guid, string>(location.City.Id, location.Name);
            //}
            return null;
        }

        //// POST api/Location
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/Location/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/Location/5
        //public void Delete(int id)
        //{
        //}

    }
}
