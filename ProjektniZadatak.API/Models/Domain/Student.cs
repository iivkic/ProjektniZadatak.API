namespace ProjektniZadatak.API.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentCode { get; set; }

        // Foreign key property
        public int TeacherId { get; set; }

        // Navigation properties
        public Teacher Teacher { get; set; } = null!;
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
