using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models.RW;

namespace WhatsHappening.Domain.Implementation.Models
{
    public class Country : ICountryRW
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
    }
}
