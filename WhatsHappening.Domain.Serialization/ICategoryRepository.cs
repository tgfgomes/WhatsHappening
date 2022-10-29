using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;

namespace WhatsHappening.Domain.Serialization
{
    public interface ICategoryRepository : IRepository
    {
        ICategory Get(Guid id);
        IEnumerable<ICategory> GetAll();
        IEnumerable<ICategory> Search(string searchTerm);
        ICategory GetByName(string name);
        Guid Add(string name);
    }
}
