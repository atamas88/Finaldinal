using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergGateway.Services
{
    public class TagGatewayService
    {
        public IEnumerable<Tag> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Tag/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Tag>>().Result;
            }
        }

        //public Tag Add(Tag Tag)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage response =
        //            client.PostAsJsonAsync("http://localhost:17348/api/Tag/", Tag).Result;
        //        return response.Content.ReadAsAsync<Tag>().Result;
        //    }
        //}

        public Tag Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Tag/" + id).Result;
                return response.Content.ReadAsAsync<Tag>().Result;
            }
        }

        public void Delete(Tag Tag)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:17348/api/Tag/" + Tag.Id).Result;

            }
        }
        public Tag Update(Tag Tag)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:17348/api/Tag/" + Tag.Id, Tag).Result;
                return response.Content.ReadAsAsync<Tag>().Result;
            }

        }
    }
}
