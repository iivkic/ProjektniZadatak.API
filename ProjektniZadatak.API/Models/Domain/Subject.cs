namespace ProjektniZadatak.API.Models.Domain
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        // Foreign key properties
        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        // Navigation properties
        public Teacher Teacher { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
