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
    public class BadgeController : ApiController
    {
        private Facade facade = new Facade();
        public IEnumerable<Badge> GetBadges()
        {
            return facade.GetBadgeRepository().ReadAll();
        }

        public Badge GetBadge(int id)
        {
            return facade.GetBadgeRepository().Find(id);
        }

        public void PostBadge(Badge Badge)
        {
            facade.GetBadgeRepository().Add(Badge);

        }

        public void DeleteBadge(int id)
        {
            Badge Badge = facade.GetBadgeRepository().Find(id);
            if (Badge == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetBadgeRepository().Delete(id);
        }

        public void PutBadge(int id, Badge Badge)
        {
            Badge.Id = id;
            facade.GetBadgeRepository().Edit(Badge);
        }
    }
}
