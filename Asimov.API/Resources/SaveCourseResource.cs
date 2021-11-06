using System.ComponentModel.DataAnnotations;

namespace Asimov.API.Resources
{
    public class SaveCourseResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Description { get; set; }
        
        [Required]
        public bool State { get; set; }
    }
}