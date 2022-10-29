using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;

namespace WhatsHappening.Domain.Services
{
    public interface ICategoryServices
    {
        IEnumerable<ICategory> Search(string searchTerm);
        IEnumerable<ICategory> GetAll();
        ICategory Get(Guid categoryId);
        ICategory FindOrAddNew(string name);
    }
}
