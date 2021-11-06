using System.ComponentModel.DataAnnotations;

namespace Asimov.API.Resources
{
    public class SaveItemResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        public string Value { get; set; }
        
        [Required]
        public bool State { get; set; }
        
        [Required]
        public int CourseId { get; set; }
    }
}