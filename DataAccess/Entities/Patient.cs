using System;

namespace DataAccess.Entities
{
    public class Patient
    {
        public int ID { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int SSN { get; set; }
    }
}
