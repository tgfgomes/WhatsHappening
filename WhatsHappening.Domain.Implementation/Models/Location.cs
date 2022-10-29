using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Domain.Serialization;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Implementation.Models
{
    public class Location : ILocationRW
    {
        public Location(ILocationServices locationServices)
        {
            Services = locationServices;
        }

        public ICountry Country { get; set; }
        public ICity City { get; set; }

        public void Set(ICity city)
        {
            City = city;
            Country = city.GetCountry();
        }

        public string Name { get { return City.Name + ", " + Country.Name; } }
        public ILocationServices Services { get; set; }

        
    }
}