namespace Dota2API.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public class Resources
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Link { get; set; }
        public string Language { get; set; }
    }
}