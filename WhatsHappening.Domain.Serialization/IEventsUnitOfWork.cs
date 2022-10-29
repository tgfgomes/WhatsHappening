using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Serialization
{
    public interface IEventsUnitOfWork : IUnitOfWork
    {
        IEventRepository EventRepository { get; }
        ILocationRepository LocationRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }
        ICategoryRepository CategoryRepository { get; }
    }
}
