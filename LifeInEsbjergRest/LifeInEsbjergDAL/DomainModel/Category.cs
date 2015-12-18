using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergDAL.DomainModel
{
    [DataContract(IsReference = true)]
    [Table("Category")]
    public class Category
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

      
        public virtual ICollection<Company> Companies { get; set; }
    }
}
