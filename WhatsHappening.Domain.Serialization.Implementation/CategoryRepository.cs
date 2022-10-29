using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Data.EF;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Models.RW;
using WhatsHappening.Infrastructure;

namespace WhatsHappening.Domain.Serialization.Implementation
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(IResolverService resolverService)
            : base(resolverService)
        {
        }

        public ICategory Get(Guid id)
        {
            ICategoryRW cat = _resolverService.Resolve<ICategoryRW>();
            return Get(id, cat);
        }

        public IEnumerable<ICategory> GetAll()
        {
            foreach (var category in DbContext.Category)
            {
                yield return EfToToNewCategory(category);
            }
        }

        public IEnumerable<ICategory> Search(string searchTerm)
        {
            foreach (var category in DbContext.Category.Where(p => p.name.ToLower().Contains(searchTerm.ToLower())))
            {
                yield return EfToToNewCategory(category);
            }
        }


        private ICategory Get(Guid id, ICategoryRW cat)
        {
            Data.EF.Category category = DbContext.Category.Local.SingleOrDefault(p => p.id == id);
            if (category == default(Data.EF.Category))
            {
                category = DbContext.Category.Single(p => p.id == id);
            }
            return EfToToCategory(cat, category);
        }

        private ICategory EfToToNewCategory(Data.EF.Category category)
        {
            ICategoryRW cat = _resolverService.Resolve<ICategoryRW>();
            return EfToToCategory(cat, category);
        }

        private ICategory EfToToCategory(ICategoryRW cat, Data.EF.Category category)
        {
            cat.Id = category.id;
            cat.Name = category.name;
            return cat;
        }

        public ICategory GetByName(string name)
        {
            ICategoryRW cat = _resolverService.Resolve<ICategoryRW>();
            name = name.ToLower();
            Data.EF.Category category = DbContext.Category.Local.SingleOrDefault(p => p.name.ToLower() == name);
            if (category == default(Category))
            {
                category = DbContext.Category.SingleOrDefault(p => p.name.ToLower() == name);
            }
            if (category == default(Category))
            {
                return null;
            }
            return EfToToCategory(cat, category);
        }

        public Guid Add(string name)
        {
            Data.EF.Category category = new Data.EF.Category();
            category.id = Guid.NewGuid();
            category.name = name;
            DbContext.Category.Add(category);
            return category.id;
        }

    }
}
