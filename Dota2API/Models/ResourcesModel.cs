namespace Dota2API.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public class ResourcesModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Resource { get; set; }
        public Languages Language { get; set; }

        private ParserTypeEnum m_parserType = ParserTypeEnum.Default;
        public ParserTypeEnum ParserType 
        { 
            get { return m_parserType; } 
            set { m_parserType = value; } 
        }
    }


}