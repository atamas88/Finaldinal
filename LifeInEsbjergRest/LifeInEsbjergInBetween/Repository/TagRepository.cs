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
    public class TagRepository : IRepository<Tag>
    {
        public void Add(Tag item)
        {
            using (var ctx = new LifeInContext())
            {
                ctx.Tags.Attach(item);
                ctx.Tags.Add(item);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Tag tag = Find(id);
            using (var ctx = new LifeInContext())
            {
                ctx.Tags.Attach(tag);
                ctx.Tags.Remove(tag);
                ctx.SaveChanges();
            }
        }

        public void Edit(Tag item)
        {
            using (var ctx = new LifeInContext())
            {
                var tagDB = ctx.Tags.FirstOrDefault(x => x.Id == item.Id);

                tagDB.Name = item.Name;
                ctx.SaveChanges();
            }
        }

        public Tag Find(int id)
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

        public List<Tag> ReadAll()
        {
            using (var ctx = new LifeInContext())
            {
                return ctx.Tags.ToList();
            }
        }
    }
}
