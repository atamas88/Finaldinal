using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeInEsbjerg.Models.ViewModel
{
    public class ReviewViewModel
    {
        public Company company { get; set; }

        public Review review { get; set; }
    }
}