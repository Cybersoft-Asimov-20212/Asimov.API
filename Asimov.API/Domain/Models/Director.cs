using System.Collections;
using System.Collections.Generic;

namespace Asimov.API.Domain.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IList<Announcement> Announcements { get; set; } = new List<Announcement>();
    }
}