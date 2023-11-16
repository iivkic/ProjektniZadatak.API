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
    public class FourthMethodController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public FourthMethodController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        [HttpPost]
        public async Task<IEnumerable<Teacher>> SelectSubject(SelectNameRequestDto request)
        {

            var query = from teacher in dbContext.Teachers
                        join subject in dbContext.Subjects on teacher.Id equals subject.TeacherId
                        join student in dbContext.Students on subject.StudentId equals student.Id
                        where student.FirstName.Contains(request.FirstName) && student.LastName.Contains(request.LastName) && subject.SubjectName.Contains(request.SubjectName)
                        select teacher;

            return await query.Distinct().ToListAsync();

        }
    }
}
