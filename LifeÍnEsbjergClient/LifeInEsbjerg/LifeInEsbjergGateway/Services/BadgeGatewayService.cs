using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergGateway.Services
{
    public class BadgeGatewayService
    {
        public IEnumerable<Badge> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Badge/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Badge>>().Result;
            }
        }

        //public Badge Add(Badge Badge)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage response =
        //            client.PostAsJsonAsync("http://localhost:17348/api/Badge/", Badge).Result;
        //        return response.Content.ReadAsAsync<Badge>().Result;
        //    }
        //}

        public Badge Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Badge/" + id).Result;
                return response.Content.ReadAsAsync<Badge>().Result;
            }
        }

        public void Delete(Badge Badge)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:17348/api/Badge/" + Badge.Id).Result;

            }
        }
        public Badge Update(Badge Badge)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:17348/api/Badge/" + Badge.Id, Badge).Result;
                return response.Content.ReadAsAsync<Badge>().Result;
            }

        }
    }
}
