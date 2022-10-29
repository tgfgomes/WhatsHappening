using System.Web.Http;

using Unity.AspNet.WebApi;

using WhatsHappening.Web.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WhatsHappening.Web.UnityWebApiActivator), nameof(WhatsHappening.Web.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WhatsHappening.Web.UnityWebApiActivator), nameof(WhatsHappening.Web.UnityWebApiActivator.Shutdown))]

namespace WhatsHappening.Web
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
            var resolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.GetConfiguredContainer().Dispose();
        }
    }
}