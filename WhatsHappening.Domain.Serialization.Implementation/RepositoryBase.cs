using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Data.EF;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Serialization.Implementation
{
    public class RepositoryBase : IRepository, IDisposable
    {
        protected readonly IResolverService _resolverService;

        public RepositoryBase(IResolverService resolverService)
        {
            _resolverService = resolverService;
        }

        public WhatsHappeningEntities DbContext { get; set; }

        public virtual void Dispose()
        {
            DbContext.Dispose();
        }

    }
}
