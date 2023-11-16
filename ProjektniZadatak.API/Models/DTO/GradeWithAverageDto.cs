using ProjektniZadatak.API.Models.Domain;

namespace ProjektniZadatak.API.Models.DTO
{
    public class GradeWithAverageDto
    {
        public Grade Grade { get; set; }
        public double AverageGrade { get; set; }
    }
}
