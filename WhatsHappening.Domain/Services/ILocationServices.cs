using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;

namespace WhatsHappening.Domain.Services
{
    public interface ILocationServices
    {
        IEnumerable<ICountry> GetCountries();
        ICountry GetCountry(Guid countryId);
        ICountry GetCountryForCity(Guid cityId);

        IEnumerable<ICity> GetCities(Guid countryId);
        ICity GetCity(Guid cityId);

        IEnumerable<ILocation> Search(string searchTerm);
        ILocation GetLocationByCity(Guid cityId);

        ILocation FindLocationOrCreate(string cityName, string countryName);
    }
}
