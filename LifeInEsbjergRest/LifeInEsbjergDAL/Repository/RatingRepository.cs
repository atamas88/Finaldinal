using LifeInEsbjergDAL.Context;
using LifeInEsbjergDAL.DomainModel;
using LifeInEsbjergDAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergDAL.Repository
{
    public class RatingRepository : IRepository<Rating>
    {
        private List<Rating> ratings = new List<Rating>();
        public void Add(Rating item)
        {
            using (var ctx = new LifeInContext())
            {
                ctx.Ratings.Attach(item);
                ctx.Ratings.Add(item);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Rating rating = new Rating();
            using (var ctx = new LifeInContext())
            {
                ctx.Ratings.Attach(rating);
                ctx.Ratings.Remove(rating);
                ctx.SaveChanges();

            }
        }

        public void Edit(Rating item)
        {
            using (var ctx = new LifeInContext())
            {
                var ratingDB = ctx.Ratings.FirstOrDefault(x => x.Id == item.Id);

                ratingDB.OverAll = item.OverAll;
                ratingDB.Price = item.Price;
                ratingDB.Quality = item.Quality;
                ctx.SaveChanges();
            }
        }

        public Rating Find(int id)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null;
        }

        public List<Rating> ReadAll()
        {
            using (var ctx = new LifeInContext())
            {
                return ctx.Ratings.ToList();
            }
        }
    }
}
