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
    public class CategoryRepository : IRepository<Category>
    {
        private List<Category> categories = new List<Category>();

        public void Add(Category category)
        {
            using (var ctx = new LifeInContext())
            {
                ctx.Categories.Attach(category);
                ctx.Categories.Add(category);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Category category = Find(id);
            using (var ctx = new LifeInContext())
            {
                ctx.Categories.Attach(category);
                ctx.Categories.Remove(category);
                ctx.SaveChanges();
            }
        }

        public void Edit(Category category)
        {
            using (var ctx = new LifeInContext())
            {
                var categoryDB = ctx.Companies.FirstOrDefault(x => x.Id == category.Id);

                categoryDB.Name = category.Name;
                ctx.SaveChanges();
            }
        }

        public Category Find(int id)
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

        public List<Category> ReadAll()
        {
            using (var ctx = new LifeInContext())
            {
                return ctx.Categories.ToList();
            }
        }
    }
}
