using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeInEsbjerg.Models.ViewModel
{
    public class RatingViewModel
    {
        public Company company { get; set; }

        public Rating rating { get; set; }
    }
}