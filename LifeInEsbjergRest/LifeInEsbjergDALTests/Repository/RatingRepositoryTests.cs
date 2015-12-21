using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeInEsbjergDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeInEsbjergDAL.DomainModel;
using LifeInEsbjergDAL.Context;

namespace LifeInEsbjergDAL.Repository.Tests
{
    [TestClass()]
    public class RatingRepositoryTests
    {
        RatingRepository repo = new RatingRepository();
        List<Rating> ratings = new List<Rating>();
        public List<Rating> Ratings()
        {
            using (var ctx = new LifeInContext())
            {
                return ctx.Ratings.ToList();
            }
        }


        [TestMethod()]
        public void AddandDeleteTest()
        {
            List<Rating> expected = Ratings();
            Rating Rating = new Rating() { Id = 13, CustomerService = 8 , Quality = 6, OverAll = 8, Price = 8 };

            expected.Add(Rating);
            repo.Add(Rating);
            List<Rating> actual = repo.ReadAll();
            Rating actuall = actual.Last();
            Assert.IsTrue(comparer(Rating, actuall));

            repo.Delete(Rating.Id);
            expected.Remove(Rating);

            Assert.IsTrue(listcomparer(repo.ReadAll(), expected));

        }


        [TestMethod()]
        public void EditTest()
        {
            Rating Rating = repo.Find(1);
            Rating.OverAll = 8;
            repo.Edit(Rating);
            Rating actual = repo.Find(1);
            Assert.IsTrue(comparer(Rating, actual));
        }

        [TestMethod()]
        public void FindTest()
        {
            Rating expected = new Rating();
            ratings = Ratings();
            foreach (var item in ratings)
            {
                if (item.Id == 1)
                {
                    expected = item;
                }

            }
            Rating actual = repo.Find(1);

            Assert.IsTrue(comparer(expected, actual));

        }

        [TestMethod()]
        public void ReadAllTest()
        {
            List<Rating> expected = Ratings();
            List<Rating> actual = repo.ReadAll();
            Assert.IsTrue(listcomparer(expected, actual));
        }

        public bool comparer(Rating a, Rating b)
        {
            if (a.OverAll == b.OverAll && a.Id == b.Id)
            {
                return true;
            }
            return false;
        }

        public bool listcomparer(List<Rating> a, List<Rating> b)
        {
            bool equals = true;
            if (a.Count() != b.Count())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.Count(); ++i)
                {
                    if (!comparer(a[i], b[i]))
                    {
                        equals = false;
                    }
                }
            }
            return equals;
        }
    }
}