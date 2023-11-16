namespace ProjektniZadatak.API.Models.Domain
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string CreatedOn { get; set; }

        // Foreign key property
        public int SubjectId { get; set; }

        // Navigation property
        public Subject Subject { get; set; } = null!;
    }
}
