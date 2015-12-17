using LifeInEsbjergDAL.Context;
using LifeInEsbjergDAL.DomainModel;
using LifeInEsbjergDAL.Repository.Interface;
using LifeInEsbjergRest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergDAL.Repository
{
    public class BadgeRepository : IRepository<Badge>
    {
        public void Add(Badge item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Badges.Attach(item);
                ctx.Badges.Add(item);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Badge Badge = Find(id);
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Badges.Attach(Badge);
                ctx.Badges.Remove(Badge);
                ctx.SaveChanges();
            }
        }

        public void Edit(Badge item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var BadgeDB = ctx.Badges.FirstOrDefault(x => x.Id == item.Id);

                BadgeDB.Name = item.Name;
                ctx.SaveChanges();
            }
        }

        public Badge Find(int id)
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

        public List<Badge> ReadAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Badges.ToList();
            }
        }
    }
}
