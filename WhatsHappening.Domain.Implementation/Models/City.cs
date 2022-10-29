using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Domain.Services;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Implementation.Models
{
    public class City : ICityRW
    {
        private ICountry _country;
        private Lazy<IResolverService> _resolverService;

        public City(Lazy<IResolverService> resolverService)
        {
            _resolverService = resolverService;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICountry GetCountry()
        {
            LoadCountry();
            return _country;
        }

        public void SetCountry(ICountry country)
        {
            _country = country;
        }

        public void LoadCountry()
        {
            if (_country == null)
            {
                ILocationServices locationServices = _resolverService.Value.Resolve<ILocationServices>();
                _country = locationServices.GetCountryForCity(Id);
            }
        }


    }
}
