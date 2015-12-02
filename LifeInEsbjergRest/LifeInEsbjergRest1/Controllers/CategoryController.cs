using LifeInEsbjergDAL;
using LifeInEsbjergDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LifeInEsbjergRest1.Controllers
{
    public class CategoryController : ApiController
    {
        private Facade facade = new Facade();
        public IEnumerable<Category> GetCategories()
        {
            return facade.GetCategoryRepository().ReadAll();
        }


        public void PostCategory(Category category)
        {
            facade.GetCategoryRepository().Add(category);

        }

        public void DeleteCategory(int id)
        {
            Category category = facade.GetCategoryRepository().Find(id);
            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetCategoryRepository().Delete(id);
        }

        public void PutCategory(int id, Category category)
        {
            category.Id = id;
            facade.GetCategoryRepository().Edit(category);
        }
        
    }
}
