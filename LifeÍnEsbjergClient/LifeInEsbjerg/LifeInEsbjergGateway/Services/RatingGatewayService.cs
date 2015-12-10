using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergGateway.Services
{
    public class RatingGatewayService
    {
        public IEnumerable<Rating> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Rating/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Rating>>().Result;
            }
        }

        public Rating Add(Rating Rating)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:17348/api/Rating/", Rating).Result;
                return response.Content.ReadAsAsync<Rating>().Result;
            }
        }

        public Rating Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Rating/" + id).Result;
                return response.Content.ReadAsAsync<Rating>().Result;
            }
        }

        public void Delete(Rating Rating)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:17348/api/Rating/" + Rating.Id).Result;

            }
        }
        public Rating Update(Rating Rating)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:17348/api/Rating/" + Rating.Id, Rating).Result;
                return response.Content.ReadAsAsync<Rating>().Result;
            }

        }
    }
}
