using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Models.RW
{
    public interface ICategoryRW : ICategory
    {
        new Guid Id { get; set; }
        new string Name { get; set; }
    }
}
