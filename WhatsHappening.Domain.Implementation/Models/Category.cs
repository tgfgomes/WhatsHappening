using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Domain.Serialization;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Implementation.Models
{
    public class Category : ICategoryRW
    {
        private readonly Lazy<IEventsUnitOfWork> _eventsUnitOfWork;

        public Category(ICategoryServices categoryServices, Lazy<IEventsUnitOfWork> eventsUnitOfWork)
        {
            Services = categoryServices;
            _eventsUnitOfWork = eventsUnitOfWork;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICategoryServices Services { get; private set; }
        //public IEnumerable<IEvent> Events { get; private set; }

        //public void Load(Guid id)
        //{
        //    _eventsUnitOfWork.Value.CategoryRepository.Load(this, id);
        //}


    }
}
