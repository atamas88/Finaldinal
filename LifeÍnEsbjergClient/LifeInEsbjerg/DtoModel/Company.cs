using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class Company
    {
            public int Id { get; set; }
            
            public int CVR { get; set; }
            public string Name { get; set; }

            public string ImageUrl { get; set; }

            public string Address { get; set; }
            
            public string WebSite { get; set; }

            
            public string Tel { get; set; }

            
            public string OpenHours { get; set; }

            public double MinPrice { get; set; }

            public double MaxPrice { get; set; }

            public string Description { get; set; }

            public int NrRate { get; set; }
            public double AvgOvr
            {
                get
                {
                  
                    return Math.Round(overall / 10, 2); 
                } }
            //[ForeignKey("Category_Id")]
            public virtual Category Category { get; set; }
            //public int Category_Id { get; set; }
            public virtual IEnumerable<Tag> Tags { get; set; }
    
            public virtual IEnumerable<Rating> Ratings { get; set; }
       
            public virtual IEnumerable<Review> Reviews { get; set; }
           
            public virtual IEnumerable<Badge> Badges { get; set; }

        public double avgQua
        {
            get
            {
                if (NrRate != 0)
                {
                    double sum = 0;
                    double nr = 0;
                    for (int i = 0; i < Ratings.Count(); i++)
                    {
                        sum += Ratings.ElementAt(i).Quality;
                        ++nr;
                    }
                    return (sum / nr) * 10;
                }
                return 0;
            } }

        public double avgCust
        {
            get
            {
                if (NrRate != 0)
                {
                    double sum = 0;
                    double nr = 0;
                    for (int i = 0; i < Ratings.Count(); i++)
                    {
                        sum += Ratings.ElementAt(i).CustomerService;
                        ++nr;
                    }

                    return (sum / nr) * 10;
                }
                return 0;
            }
        }

        public double avgPrice
        {
            get
            {
                if (NrRate != 0)
                {
                    double sum = 0;
                    double nr = 0;
                    for (int i = 0; i < Ratings.Count(); i++)
                    {
                        sum += Ratings.ElementAt(i).Price;
                        ++nr;
                    }
                    return (sum / nr) * 10;
                }
                return 0;
            }
        }

        public double overall
        {
            get
            {
                if (NrRate != 0)
                {
                    
                    return (avgCust + avgPrice + avgQua) / 3;
                }
                return 0;
            }
        }


    }
}

