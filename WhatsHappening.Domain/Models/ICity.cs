using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Models
{
    public interface ICity
    {
        Guid Id { get;  }
        string Name { get; set; }
        ICountry GetCountry();
        void SetCountry(ICountry country);
    }
}
