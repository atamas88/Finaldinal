using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergGateway.Services
{
    public class CategoryGatewayService
    {
        public IEnumerable<Category> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Category/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            }
        }

        //public Category Add(Category Category)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage response =
        //            client.PostAsJsonAsync("http://localhost:17348/api/Category/", Category).Result;
        //        return response.Content.ReadAsAsync<Category>().Result;
        //    }
        //}

        public Category Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Category/" + id).Result;
                return response.Content.ReadAsAsync<Category>().Result;
            }
        }

        public void Delete(Category Category)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:17348/api/Category/" + Category.Id).Result;

            }
        }
        public Category Update(Category Category)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:17348/api/Category/" + Category.Id, Category).Result;
                return response.Content.ReadAsAsync<Category>().Result;
            }

        }


    }
}
