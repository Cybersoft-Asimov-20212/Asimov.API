using System.ComponentModel.DataAnnotations;

namespace Asimov.API.Competences.Resources
{
    public class SaveCompetenceResource
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }
}