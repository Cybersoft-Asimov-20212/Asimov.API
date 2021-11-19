namespace Asimov.API.Domain.Models
{
    public class CourseCompetence
    {
        public int CourseId { get; set; }
        public int CompetenceId { get; set; }
        
        public Course Course { get; set; }
        public Competence Competence { get; set; }
    }
}