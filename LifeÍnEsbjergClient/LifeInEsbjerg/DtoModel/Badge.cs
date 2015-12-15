using Newtonsoft.Json;
using System.Collections.Generic;

namespace DtoModel
{
    public class Badge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Company> Companies { get; set; }

        public string ImgPath { get; set; }

    }
}