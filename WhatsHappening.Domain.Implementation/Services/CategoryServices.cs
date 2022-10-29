using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Serialization;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Domain.Implementation.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly Lazy<IEventsUnitOfWork> _eventsUnitOfWork;

        public CategoryServices(Lazy<IEventsUnitOfWork> eventsUnitOfWork)
        {
            _eventsUnitOfWork = eventsUnitOfWork;
        }

        public IEnumerable<ICategory> Search(string searchTerm)
        {
            return _eventsUnitOfWork.Value.CategoryRepository.Search(searchTerm);
        }

        public ICategory FindOrAddNew(string name)
        {
            var category = _eventsUnitOfWork.Value.CategoryRepository.GetByName(name);
            if (category == default(ICategory))
            {
                var categoryId = _eventsUnitOfWork.Value.CategoryRepository.Add(name);
                _eventsUnitOfWork.Value.Commit();
                category = _eventsUnitOfWork.Value.CategoryRepository.Get(categoryId);
            }
            return category;
        }

        public IEnumerable<ICategory> GetAll()
        {
            return _eventsUnitOfWork.Value.CategoryRepository.GetAll();
        }

        public ICategory Get(Guid categoryId)
        {
            return _eventsUnitOfWork.Value.CategoryRepository.Get(categoryId);
        }


    }
}
