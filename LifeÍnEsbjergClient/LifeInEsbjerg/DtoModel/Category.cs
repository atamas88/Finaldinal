using System;
using System.Collections.Generic;

namespace DtoModel
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Company> Companies { get; set; }

    }
}