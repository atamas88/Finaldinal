using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergGateway.Services
{
    public class CompanyGatewayService
    {
        public IEnumerable<Company> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/company/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Company>>().Result;
            }
        }

        public Company Add(Company company)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:17348/api/company/", company).Result;
                return response.Content.ReadAsAsync<Company>().Result;
            }
        }

        public Company Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/company/" + id).Result;
                return response.Content.ReadAsAsync<Company>().Result;
            }
        }

        public void Delete(Company company)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:17348/api/company/" + company.Id).Result;

            }
        }
        public Company Update(Company company)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:17348/api/company/" + company.Id, company).Result;
                return response.Content.ReadAsAsync<Company>().Result;
            }

        }

    }
}
