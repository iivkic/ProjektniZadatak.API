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
    public class ThirdMethodController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ThirdMethodController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        [HttpPost]
        public async Task<IEnumerable<Subject>> SelectSubject(SelectRequestDto request)
        {

            var query = from subject in dbContext.Subjects
                        join student in dbContext.Students on subject.StudentId equals student.Id
                        where student.FirstName.Contains(request.FirstName) && student.LastName.Contains(request.LastName)
                        select subject;

            var distinctSubjects = await query
                .GroupBy(sub => sub.SubjectName)  
                .Select(group => group.First())  
                .ToListAsync();

            return distinctSubjects;

        }
    }
}

