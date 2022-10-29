using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Data.EF;

namespace WhatsHappening.Domain.Serialization.Implementation
{
    public class EventsUnitOfWork : IEventsUnitOfWork
    {
        private readonly Lazy<WhatsHappeningEntities> _dbContext;
        private readonly Lazy<IEventRepository> _eventsRepository;
        private readonly Lazy<ICountryRepository> _countryRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ILocationRepository> _locationRepository;

        public EventsUnitOfWork(Lazy<WhatsHappeningEntities> dbContext, Lazy<IEventRepository> eventsRepository, Lazy<ICategoryRepository> categoryRepository, Lazy<ILocationRepository> locationRepository, Lazy<ICountryRepository> countryRepository, Lazy<ICityRepository> cityRepository)
        {
            _dbContext = dbContext;
            _eventsRepository = eventsRepository;
            _categoryRepository = categoryRepository;
            _locationRepository = locationRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        public IEventRepository EventRepository
        {
            get
            {
                _eventsRepository.Value.DbContext = _dbContext.Value;
                return _eventsRepository.Value;
            }
        }

        public ILocationRepository LocationRepository
        {
            get
            {
                _locationRepository.Value.DbContext = _dbContext.Value;
                return _locationRepository.Value;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                _categoryRepository.Value.DbContext = _dbContext.Value;
                return _categoryRepository.Value;
            }
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                _countryRepository.Value.DbContext = _dbContext.Value;
                return _countryRepository.Value;
            }
        }

        public ICityRepository CityRepository
        {
            get
            {
                _cityRepository.Value.DbContext = _dbContext.Value;
                return _cityRepository.Value;
            }
        }


        public void Commit()
        {
            _dbContext.Value.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Value.Dispose();
        }
    }
}
