using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Infrastructure
{
    public interface IDbContextAware
    {
        WhatsHappening.Data.EF.WhatsHappeningEntities DbContext { get; set; }
    }
}
