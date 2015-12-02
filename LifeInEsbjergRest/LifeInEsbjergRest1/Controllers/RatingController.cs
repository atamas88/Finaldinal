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
    public class RatingController : ApiController
    {
        private Facade facade = new Facade();
        public IEnumerable<Rating> GetRatings()
        {
            return facade.GetRatingRepository().ReadAll();
        }


        public void PostRating(Rating rating)
        {
            facade.GetRatingRepository().Add(rating);

        }

        public void DeleteRating(int id)
        {
            Rating Rating = facade.GetRatingRepository().Find(id);
            if (Rating == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetRatingRepository().Delete(id);
        }

        public void PutRating(int id, Rating rating)
        {
            rating.Id = id;
            facade.GetRatingRepository().Edit(rating);
        }
    }
}

