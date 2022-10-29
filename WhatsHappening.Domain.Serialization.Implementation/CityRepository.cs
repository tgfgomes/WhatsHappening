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
    public class CityRepository : RepositoryBase, ICityRepository
    {
        public CityRepository(IResolverService resolverService)
            : base(resolverService)
        {
        }

        public ICity Get(Guid cityId)
        {
            var c = DbContext.City.Local.SingleOrDefault(p => p.id == cityId);
            if (c == default(Data.EF.City))
            {
                c = DbContext.City.Single(p => p.id == cityId);
            }
            ICityRW city = _resolverService.Resolve<ICityRW>();
            city.Id = c.id;
            city.Name = c.name;
            return city;
        }

        public IEnumerable<ICity> GetCities(Guid countryId)
        {
            var q = DbContext.City.Local.Where(p => p.countryId == countryId).ToList();
            if (q.Count() == 0)
            {
                q = DbContext.City.Where(p => p.countryId == countryId).ToList();
            }
            foreach (var c in q)
            {
                ICityRW city = EfCityToICity(c);
                yield return city;
            }
        }

        private ICityRW EfCityToICity(City efCity)
        {
            ICityRW city = _resolverService.Resolve<ICityRW>();
            city.Id = efCity.id;
            city.Name = efCity.name;
            return city;
        }

        public Guid Add(string name, ICountry country)
        {
            Data.EF.City city = new Data.EF.City();
            city.id = Guid.NewGuid();
            city.name = name;
            city.countryId = country.Id;
            DbContext.City.Add(city);
            return city.id;
        }

        //public void AddNewCity(ICity city)
        //{
        //    Data.EF.City efCity = new Data.EF.City();
        //    efCity.id = Guid.NewGuid();
        //    efCity.name = city.Name;
        //    efCity.Country = DbContext.Country.Single(p => p.id == city.GetCountry().Id);
        //    DbContext.City.Add(efCity);
        //}

        public void AddNewCity(ICity city)
        {
            Add(city.Name, city.GetCountry());
        }


        public IEnumerable<ICity> Search(string cityName, string countryName = null)
        {
            //TODO: Search local first
            var q = DbContext.City.Where(p => p.name.ToLower().Contains(cityName.ToLower()));
            if (!string.IsNullOrEmpty(countryName))
                q = q.Where(p => p.Country.name.ToLower().Contains(countryName.ToLower()));
            foreach (var efCity in q)
            {
                yield return EfCityToICity(efCity);
            }
        }


        public IEnumerable<ICity> Search(IEnumerable<string> locationSearchTerms)
        {
            //TODO: Search local first
            var lst = locationSearchTerms.ToList();
            lst.ForEach(p => p = p.ToLower());
            foreach (var efCity in DbContext.City.Where(p => locationSearchTerms.Contains(p.name.ToLower())
                                                          || locationSearchTerms.Contains(p.Country.name.ToLower())))
            {
                yield return EfCityToICity(efCity);
            }
        }



    }
}
