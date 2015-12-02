using DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeInEsbjerg.Models.ViewModel
{
    public class LifeInEsbjergViewModel
    {
        public Company Company { get; set; }
        public SelectList Category { get; set; }

        public int selectedCat { get; set; }


        public MultiSelectList Tags { get; set; }

        public List<int> selectedTags { get; set; }
    }

}