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
    [Table("Rating")]
    public class Rating
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Quality { get; set; }
        [DataMember]
        public int CustomerService { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public double OverAll { get; set; }
        [DataMember]
        //[ForeignKey("Company_Id")]
        public virtual Company Company { get; set; }
        //public int Company_Id { get; set; }
        //public virtual User user { get; set; }
    }
}
