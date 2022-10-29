using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Models.RW
{
    public interface ILocationRW : ILocation
    {
        new ICountry Country { get; set; }
        new ICity City { get; set; }
    }
}
