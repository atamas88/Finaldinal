using LifeInEsbjergDAL;
using LifeInEsbjergDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LifeInEsbjergRest.Controllers
{
    public class CompanyController : ApiController
    {
        private Facade facade = new Facade();
        public IEnumerable<Company> GetCompanies()
        {
            return facade.GetCompanyRepository().ReadAll();
        }

        public Company GetCompany(int id)
        {
            return facade.GetCompanyRepository().Find(id);
        }

        public void PostCompany(Company company)
        {
            facade.GetCompanyRepository().Add(company);

        }

        public void DeleteCompany(int id)
        {
            Company Company = facade.GetCompanyRepository().Find(id);
            if (Company == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            facade.GetCompanyRepository().Delete(id);
        }

        public void PutCompany(int id, Company company)
        {
            company.Id = id;
            facade.GetCompanyRepository().Edit(company);
        }
    }
}
