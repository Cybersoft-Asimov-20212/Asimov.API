namespace Asimov.API.Domain.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        // Relationships
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}