using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Models
{
    public interface ICountry
    {
        Guid Id { get;  }
        string CountryCode { get; set; }
        string Name { get; set; }
    }
}
