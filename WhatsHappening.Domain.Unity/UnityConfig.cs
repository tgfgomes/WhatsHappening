using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
//using Microsoft.Practices.Unity;
using WhatsHappening.Domain.Implementation.Models;
using WhatsHappening.Domain.Implementation.Services;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Domain.Serialization;
using WhatsHappening.Domain.Serialization.Implementation;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Unity
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here

            container.RegisterType<IEvent, Event>();
            container.RegisterType<IEventRW, Event>();
            container.RegisterType<ICountry, Country>();
            container.RegisterType<ICountryRW, Country>();
            container.RegisterType<ICity, City>();
            container.RegisterType<ICityRW, City>();
            container.RegisterType<ILocation, Location>();
            container.RegisterType<ILocationRW, Location>();
            container.RegisterType<ICategory, Category>();
            container.RegisterType<ICategoryRW, Category>();
            container.RegisterType<IEventDate, EventDate>();
            container.RegisterType<IEventDateRW, EventDate>();

            container.RegisterType<IEventServices, EventServices>();
            container.RegisterType<ICategoryServices, CategoryServices>();
            container.RegisterType<ILocationServices, LocationServices>();

            container.RegisterType<IEventRepository, EventRepository>();
            container.RegisterType<ICountryRepository, CountryRepository>();
            container.RegisterType<ICityRepository, CityRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();

            container.RegisterType<IEventsUnitOfWork, EventsUnitOfWork>();
        }
    }
}
