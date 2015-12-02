using System;

namespace DtoModel
{
    public class Review
    {
        
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Text { get; set; }
        
        //public DateTime Date { get; set; }
        
        public virtual Company Company { get; set; }
    }
}