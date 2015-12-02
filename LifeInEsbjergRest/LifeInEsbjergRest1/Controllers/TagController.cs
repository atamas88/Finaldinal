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
    public class TagController : ApiController
    {
        private Facade facade = new Facade();
        public IEnumerable<Tag> GetTags()
        {
            return facade.GetTagRepository().ReadAll();
        }


        public void PostTag(Tag tag)
        {
            facade.GetTagRepository().Add(tag);

        }

        public void DeleteTag(int id)
        {
            Tag tag = facade.GetTagRepository().Find(id);
            if (tag == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetTagRepository().Delete(id);
        }

        public void PutTag(int id, Tag tag)
        {
            tag.Id = id;
            facade.GetTagRepository().Edit(tag);
        }
    }
}
