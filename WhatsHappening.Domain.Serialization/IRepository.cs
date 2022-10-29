using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Serialization
{
    public interface IRepository : IDbContextAware
    {
    }
}
