using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Models
{
    public interface ICategory
    {
        Guid Id { get; }
        string Name { get; }
        ICategoryServices Services { get; }
        //IEnumerable<IEvent> Events { get; }
        //void Load(Guid id);
    }
}
