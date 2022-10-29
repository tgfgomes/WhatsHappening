using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;

namespace WhatsHappening.Domain.Serialization
{
    public interface ILocationRepository : IRepository
    {
        void LoadByCity(ILocationRW location, Guid id);
        ILocation GetByCity(Guid cityId);
        IEnumerable<ILocation> Search(IEnumerable<string> locationSearchTerms);
    }
}
