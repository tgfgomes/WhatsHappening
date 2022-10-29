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
    public class CountryRepository : RepositoryBase, ICountryRepository
    {
        public CountryRepository(IResolverService resolverService)
            : base(resolverService)
        {
        }
        

        public IEnumerable<ICountry> GetCountries()
        {
            var q = DbContext.Country;
            foreach (var c in q)
            {
                yield return EfCountryToNewICountry(c);
            }
        }

        private ICountryRW EfCountryToNewICountry(Country c)
        {
            ICountryRW country = _resolverService.Resolve<ICountryRW>();
            country.Id = c.id;
            country.Name = c.name;
            country.CountryCode = c.countryCode;
            return country;
        }

        public ICountry Get(Guid id)
        {
            var c = DbContext.Country.Local.SingleOrDefault(p => p.id == id);
            if (c == default(Data.EF.Country))
            {
                c = DbContext.Country.Single(p => p.id == id);
            }
            return EfCountryToNewICountry(c);
        }

        public ICountry GetCountryForCity(Guid cityId)
        {
            var efcountry = DbContext.Country.Local.SingleOrDefault(p => p.City.Any(c => c.id == cityId));
            if (efcountry == default(Data.EF.Country))
            {
                efcountry = DbContext.Country.Single(p => p.City.Any(c => c.id == cityId));
            }
            return EfCountryToNewICountry(efcountry);
        }

        public ICountry GetByName(string countryName)
        {
            countryName = countryName.ToLower();
            var efcountry = DbContext.Country.Local.SingleOrDefault(p => p.name.ToLower() == countryName);
            if (efcountry == default(Data.EF.Country))
            {
                efcountry = DbContext.Country.Single(p => p.name.ToLower() == countryName);
            }
            return EfCountryToNewICountry(efcountry);
        }

        public Guid Add(string name, string countryCode)
        {
            Data.EF.Country country = new Data.EF.Country();
            country.id = Guid.NewGuid();
            country.name = name;
            country.countryCode = countryCode;
            DbContext.Country.Add(country);
            return country.id;
        }
    }

}
