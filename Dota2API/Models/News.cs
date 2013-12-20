namespace Dota2API.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;
    
    public class News
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public DateTime PublishDate { get; set; }
        public int ResourceId { get; set; }
        
        // link
        public Resources Resource { get; set; }
    }
}