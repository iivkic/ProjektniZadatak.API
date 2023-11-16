using ProjektniZadatak.API.Models.Domain;

namespace ProjektniZadatak.API.Repositories.Interface
{
    public interface IFirstMethodRepository
    {
        Task<IEnumerable<Student>> SelectStudents(string firstName, string lastName);
    }
   
}
