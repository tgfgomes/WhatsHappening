using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsHappening.Domain.Services;

namespace WhatsHappening.Controllers
{
    public class CategoriesController : ApiController
    {
        private ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET api/Categories
        public IEnumerable<KeyValuePair<Guid, string>> Get()
        {
            foreach (var category in _categoryServices.GetAll())
            {
                yield return new KeyValuePair<Guid, string>(category.Id, category.Name);
            }
        }

        //// GET api/Categories/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/Categories
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/Categories/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/Categories/5
        //public void Delete(int id)
        //{
        //}
    }
}
