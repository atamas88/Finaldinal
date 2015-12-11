using Newtonsoft.Json;

namespace DtoModel
{
    public class Rating
    {

        public int Id { get; set; }

        public int Quality { get; set; }

        public int CustomerService { get; set; }

        public int Price { get; set; }

        public double OverAll { get; set; }
        [JsonIgnore]
        public virtual Company Company { get; set; }

       
        //public virtual User user { get; set; }
    }
}