using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Domain.Serialization;
using WhatsHappening.Domain.Services;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Implementation.Services
{
    public class LocationServices : ILocationServices
    {
        private readonly Lazy<IEventsUnitOfWork> _eventsUnitOfWork;
        private readonly Lazy<IResolverService> _resolverService;

        public LocationServices(Lazy<IResolverService> resolverService, Lazy<IEventsUnitOfWork> eventsUnitOfWork)
        {
            _eventsUnitOfWork = eventsUnitOfWork;
            _resolverService = resolverService;
        }

        public IEnumerable<ICountry> GetCountries()
        {
            return _eventsUnitOfWork.Value.CountryRepository.GetCountries();
        }

        public IEnumerable<ICity> GetCities(Guid countryId)
        {
            return _eventsUnitOfWork.Value.CityRepository.GetCities(countryId);
        }

        public IEnumerable<ILocation> Search(string searchTerm)
        {
            return _eventsUnitOfWork.Value.LocationRepository.Search(new List<string> { searchTerm });
        }

        public IEnumerable<ILocation> Search(IEnumerable<string> searchTerms)
        {
            //var cities = _eventsUnitOfWork.Value.CityRepository.Search(searchTerms);
            //foreach (var item in cities)
            //{
            //    ILocationRW loc = _resolverService.Value.Resolve<ILocationRW>();
            //    loc.City = item.Name
            //}

            return _eventsUnitOfWork.Value.LocationRepository.Search(searchTerms);
        }


        public ICountry GetCountry(Guid countryId)
        {
            return _eventsUnitOfWork.Value.CountryRepository.Get(countryId);
        }

        public ICity GetCity(Guid cityId)
        {
            return _eventsUnitOfWork.Value.CityRepository.Get(cityId);
        }

        public ILocation GetLocationByCity(Guid cityId)
        {
            ILocationRW locationRW = _resolverService.Value.Resolve<ILocationRW>();
            _eventsUnitOfWork.Value.LocationRepository.LoadByCity(locationRW, cityId);
            return locationRW;
        }

        public ICountry GetCountryForCity(Guid cityId)
        {
            return _eventsUnitOfWork.Value.CountryRepository.GetCountryForCity(cityId);
        }

        public ILocation FindLocationOrCreate(string cityName, string countryName)
        {
            var city = _eventsUnitOfWork.Value.CityRepository.Search(cityName, countryName).FirstOrDefault();
            if (city == null)
            {
                var country = _eventsUnitOfWork.Value.CountryRepository.GetByName(countryName);
                if (country == null)
                {
                    var countryId = _eventsUnitOfWork.Value.CountryRepository.Add(country.Name, "UNKNOWN");
                    country = _eventsUnitOfWork.Value.CountryRepository.Get(countryId);
                }
                var cityId = _eventsUnitOfWork.Value.CityRepository.Add(cityName, country);
                city = _eventsUnitOfWork.Value.CityRepository.Get(cityId);
                _eventsUnitOfWork.Value.Commit();
            }
            return GetLocationByCity(city.Id);
        }

    }
}
