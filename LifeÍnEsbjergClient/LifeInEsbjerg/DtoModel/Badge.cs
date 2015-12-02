using System.Collections.Generic;

namespace DtoModel
{
    public class Badge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Company> Companies { get; set; }

    }
}