using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;

namespace WhatsHappening.ApplicationServices
{
    public interface IEventAppServices
    {
        IEvent CreateEvent(string name, string address, ILocation location, DateTime eventDate, IEnumerable<ICategory> selectedCategoryList);
        IEvent CreateEvent(string name, string address, Guid selectedCityId, DateTime eventDate, IEnumerable<Guid> selectedCategoryIdList);
    }
}
