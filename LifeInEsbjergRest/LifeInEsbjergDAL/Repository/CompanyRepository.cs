using LifeInEsbjergDAL.Context;
using LifeInEsbjergDAL.DomainModel;
using LifeInEsbjergDAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergDAL.Repository
{
    public class CompanyRepository : IRepository<Company>
    {
        private List<Company> companies = new List<Company>();

        public List<Company> ReadAll()
        {
            using (var ctx = new LifeInContext())
            {

                //ctx.Companies.Include("Rating")
                return ctx.Companies.Include("Category").Include(c => c.Ratings).Include("Reviews").Include(c => c.Tags).Include("Badges").ToList();

            }
        }
        public void Add(Company company)
        {
            using (var ctx = new LifeInContext())
            {
                ctx.Companies.Add(company);
                foreach (var item in company.Tags)
                {
                    ctx.Tags.Remove(ctx.Tags.FirstOrDefault(x => x.Id == item.Id));
                    ctx.Tags.Attach(ctx.Tags.FirstOrDefault(x => x.Id == item.Id));
                }
                ctx.Entry(company.Category).State = EntityState.Unchanged;
                ctx.SaveChanges();
            }
    }

        public Company Find(int id)
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

        public void Delete(int id)
        {
            Company company = Find(id);
            using (var ctx = new LifeInContext())
            {
                ctx.Companies.Attach(company);
                ctx.Companies.Remove(company);
                ctx.SaveChanges();
            }
        }

        public void Edit(Company company)
        {
            using (var ctx = new LifeInContext())
            {
                var companyDB = ctx.Companies.
                    Include("Category").
                    Include("Tags").
                    Include("Ratings").
                    Include("Reviews").
                    Include("Badges").
                    FirstOrDefault(x => x.Id == company.Id);
                ctx.Entry(companyDB).CurrentValues.SetValues(company);
                companyDB.Tags.Clear();
                if (companyDB.Category.Id != company.Category.Id)
                {
                    companyDB.Category = company.Category;
                    ctx.Entry(company.Category).State = EntityState.Unchanged;
                }
                foreach (var item in company.Tags)
                {
                    companyDB.Tags.Add(ctx.Tags.FirstOrDefault(x => x.Id == item.Id));
                }
                companyDB.Ratings.Clear();
                //foreach (var item in company.Ratings)
                //{
                //    companyDB.Ratings.Add(ctx.Ratings.FirstOrDefault(x => x.Id == item.Id));
                //}

                for(int i = 0; i < company.Ratings.Count(); ++i)
                {
                    companyDB.Ratings.Add(company.Ratings.ElementAt(i));
                }

                companyDB.Reviews.Clear();
                for(int i = 0; i < company.Reviews.Count(); ++i)
                {
                    companyDB.Reviews.Add(company.Reviews.ElementAt(i));
                }

                companyDB.Badges.Clear();
                foreach (var item in company.Badges)
                {
                    companyDB.Badges.Add(ctx.Badges.FirstOrDefault(x => x.Id == item.Id));
                }
                companyDB.NrRate = companyDB.Ratings.Count();
                ctx.SaveChanges();

            }
        }
    }
}
