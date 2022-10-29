using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Data.EF;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Serialization.Implementation
{
    public class LocationRepository : RepositoryBase, ILocationRepository
    {
        public LocationRepository(IResolverService resolverService)
            : base(resolverService)
        {
        }

        public void LoadByCity(ILocationRW location, Guid cityId)
        {
            GetByCity(cityId, location);
        }

        //public ILocation GetByCity(Guid cityId)
        //{
        //    Data.EF.City city = DbContext.City.Single(p => p.id == cityId);
        //    return EfToILocation(city);
        //}

        public ILocation GetByCity(Guid cityId)
        {
            return GetByCity(cityId, null);
        }

        public IEnumerable<ILocation> Search(IEnumerable<string> locationSearchTerms)
        {
            //var q = DbContext.City.AsQueryable();
            var l = locationSearchTerms.Select(p => p.ToLower()).ToList();
            var q = DbContext.City.Where(p => l.Contains(p.name.ToLower()) || l.Contains(p.Country.name.ToLower()));
            //foreach (var searchTerm in l.Contains(p.name.ToLower()))
            //{
            //    q = q.Where(p => p.name.ToLower().Contains(searchTerm.ToLower())
            //                || p.Country.name.ToLower().Contains(searchTerm.ToLower()));
            //}
            foreach (var city in q)
            {
                yield return EfToILocation(city);
            }
        }

        private ILocation GetByCity(Guid cityId, ILocationRW loc)
        {
            var city = DbContext.City.Local.SingleOrDefault(p => p.id == cityId);
            if (city == default(Data.EF.City))
            {
                city = DbContext.City.Single(p => p.id == cityId);
            }
            if (loc == null)
                return EfToILocation(city);
            else
                return EfToILocation(city, loc);
        }

        private ILocation EfToILocation(Data.EF.City efCity)
        {
            ILocationRW loc = _resolverService.Resolve<ILocationRW>();
            return EfToILocation(efCity, loc);
        }

        private ILocation EfToILocation(Data.EF.City efCity, ILocationRW loc)
        {
            ICountryRW country = _resolverService.Resolve<ICountryRW>();
            ICityRW city = _resolverService.Resolve<ICityRW>();
            loc.Country = country;
            loc.City = city;
            city.Id = efCity.id;
            city.Name = efCity.name;
            if (efCity.countryId.HasValue)
            {
                country.Id = efCity.countryId.Value;
                country.Name = efCity.Country.name;
                country.CountryCode = efCity.Country.countryCode;
            }
            return loc;
        }







    }
}
