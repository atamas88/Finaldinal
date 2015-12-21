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
    public class CategoryRepositoryTests
    {
        CategoryRepository repo = new CategoryRepository();
        List<Category> categories = new List<Category>();
        public List<Category> Categories()
        {
            using (var ctx = new LifeInContext())
            {
                return ctx.Categories.ToList();
            }
        }


        [TestMethod()]
        public void AddandDeleteTest()
        {
            List<Category> expected = Categories();
            Category category = new Category() { Id = 9, Name = "Shop" };

            expected.Add(category);
            repo.Add(category);
            List<Category> actual = repo.ReadAll();
            Category actuall = actual.Last();
            Assert.IsTrue(comparer(category, actuall));

            repo.Delete(category.Id);
            expected.Remove(category);

            Assert.IsTrue(listcomparer(repo.ReadAll(), expected));

        }


        [TestMethod()]
        public void EditTest()
        {
            Category category = repo.Find(1);
            category.Name = "Updated";
            repo.Edit(category);
            Category actual = repo.Find(1);
            Assert.IsTrue(comparer(category, actual));
        }

        [TestMethod()]
        public void FindTest()
        {
            Category expected = new Category();
            categories = Categories();
            foreach (var item in categories)
            {
                if (item.Id == 1)
                {
                    expected = item;
                }

            }
            Category actual = repo.Find(1);

            Assert.IsTrue(comparer(expected, actual));

        }

        [TestMethod()]
        public void ReadAllTest()
        {
            List<Category> expected = Categories();
            List<Category> actual = repo.ReadAll();
            Assert.IsTrue(listcomparer(expected, actual));
        }

        public bool comparer(Category a, Category b)
        {
            if (a.Name == b.Name && a.Id == b.Id)
            {
                return true;
            }
            return false;
        }

        public bool listcomparer(List<Category> a, List<Category> b)
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