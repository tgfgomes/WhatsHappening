using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Models.RW
{
    public interface ICountryRW : ICountry
    {
        new Guid Id { get; set; }
    }
}
