using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LifeInEsbjergDAL.DomainModel
{

    [DataContract(IsReference = true)]
    [Table("Company")]
    public class Company
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CVR { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Address { get; set; }

        [StringLength(50)]
        [DataMember]
        public string WebSite { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Tel { get; set; }

        [StringLength(50)]
        [DataMember]
        public string OpenHours { get; set; }

        [DataMember]
        public double MinPrice { get; set; }

        [DataMember]
        public double MaxPrice { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int NrRate { get; set; }

        [DataMember]
        public double AvgOvr { get; set; }

        [DataMember]
        //[ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
        //public int Category_Id { get; set; }
        [DataMember]
        public virtual ICollection<Tag> Tags { get; set; }
        [DataMember]
        public  ICollection<Rating> Ratings { get; set; }
        [DataMember]
        public  ICollection<Review> Reviews { get; set; }
        [DataMember]
        public virtual ICollection<Badge> Badges { get; set; }




    }
}
