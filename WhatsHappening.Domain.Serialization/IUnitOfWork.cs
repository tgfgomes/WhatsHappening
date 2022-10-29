using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Serialization
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
