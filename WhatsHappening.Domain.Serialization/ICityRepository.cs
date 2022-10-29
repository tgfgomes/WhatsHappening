using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;

namespace WhatsHappening.Domain.Serialization
{
    public interface ICityRepository : IRepository
    {
        ICity Get(Guid cityId);
        IEnumerable<ICity> GetCities(Guid countryId);
        void AddNewCity(ICity city);
        IEnumerable<ICity> Search(string cityName, string countryName = null);
        IEnumerable<ICity> Search(IEnumerable<string> locationSearchTerms);
        Guid Add(string name, ICountry country);
    }
}
