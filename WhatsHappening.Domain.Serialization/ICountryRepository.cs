using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;

namespace WhatsHappening.Domain.Serialization
{
    public interface ICountryRepository : IRepository
    {
        ICountry Get(Guid id);
        ICountry GetByName(string name);
        IEnumerable<ICountry> GetCountries();
        ICountry GetCountryForCity(Guid cityId);
        Guid Add(string name, string countryCode);
    }
}
