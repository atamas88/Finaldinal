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
    [Table("Review")]
    public class Review
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Text { get; set; }
        //[DataMember]
        //[DataType("Date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime Date { get; set; }
        [DataMember]
        //[ForeignKey("Company_Id")]
        public virtual Company Company { get; set; }
        //public int Company_Id { set; get; }
    }
}
