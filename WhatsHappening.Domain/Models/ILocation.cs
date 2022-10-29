using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Models
{
    public interface ILocation
    {
        ICountry Country { get; }
        ICity City { get; }
        void Set(ICity City);
        string Name { get; }

        ILocationServices Services { get; }

        //Guid CityId { get; }
        //Guid CountryId { get; }
        //string City { get; }
        //string Country { get; }
        //string Name { get; }
        
        //IEnumerable<IEvent> Events { get; }
        //IEnumerable<IEvent> GetEvents() -> UoW.Rep.Get...

        //void LoadByCity(Guid cityId);
        
    }
}
