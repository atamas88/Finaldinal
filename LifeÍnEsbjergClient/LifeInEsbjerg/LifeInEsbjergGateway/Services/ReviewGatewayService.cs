using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergGateway.Services
{
    public class ReviewGatewayService
    {
        public IEnumerable<Review> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Review/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Review>>().Result;
            }
        }

        public Review Add(Review Review)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:17348/api/Review/", Review).Result;
                return response.Content.ReadAsAsync<Review>().Result;
            }
        }

        public Review Find(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:17348/api/Review/" + id).Result;
                return response.Content.ReadAsAsync<Review>().Result;
            }
        }

        public void Delete(Review Review)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:17348/api/Review/" + Review.Id).Result;

            }
        }
        public Review Update(Review Review)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:17348/api/Review/" + Review.Id, Review).Result;
                return response.Content.ReadAsAsync<Review>().Result;
            }

        }
    }
}
