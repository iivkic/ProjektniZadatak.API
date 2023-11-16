using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektniZadatak.API.Data;
using ProjektniZadatak.API.Models.Domain;
using ProjektniZadatak.API.Models.DTO;

namespace ProjektniZadatak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FifthMethodController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public FifthMethodController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        [HttpPost]
        public async Task<IEnumerable<Grade>> SelectSubject(SelectNameRequestDto request)
        {

            var query = from grade in dbContext.Grades
                        join subject in dbContext.Subjects on grade.SubjectId equals subject.Id
                        join student in dbContext.Students on subject.StudentId equals student.Id
                        where student.FirstName.Contains(request.FirstName) && student.LastName.Contains(request.LastName) && subject.SubjectName.Contains(request.SubjectName)
                        select grade;
            return await query.ToListAsync();

        }
    }
}
