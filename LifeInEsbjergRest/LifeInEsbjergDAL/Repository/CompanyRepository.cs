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

                return ctx.Companies.Include("Ratings").ToList();
                //.Include("Ratings").Include("Reviews").Include("Tags").
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
                var companyDB = ctx.Companies.FirstOrDefault(x => x.Id == company.Id);

                companyDB.CVR = company.CVR;
                companyDB.Name = company.Name;
                companyDB.ImageUrl = company.ImageUrl;
                companyDB.Address = company.Address;
                companyDB.WebSite = company.WebSite;
                companyDB.Tel = company.Tel;
                companyDB.OpenHours = company.OpenHours;
                companyDB.MinPrice = company.MinPrice;
                companyDB.MaxPrice = company.MaxPrice;
                companyDB.Description = company.Description;
                companyDB.NrRate = company.NrRate;
                companyDB.AvgOvr = company.AvgOvr;
                companyDB.Category = company.Category;
                ctx.Entry(company.Category).State = EntityState.Unchanged;

                ctx.SaveChanges();

            }
        }
    }
}
