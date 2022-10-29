using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
//using Microsoft.Practices.Unity;

namespace WhatsHappening.Infrastructure.Unity
{
    public class ResolverService : IResolverService
    {
        private IUnityContainer _unityContainer;

        public ResolverService(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

    }
}
