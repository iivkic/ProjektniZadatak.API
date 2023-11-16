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
    public class SecondMethodController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public SecondMethodController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        [HttpPost]
        public async Task<IEnumerable<Subject>> SelectSubject(SelectRequestDto request)
        {

            var query = from subject in dbContext.Subjects
                        join teacher in dbContext.Teachers on subject.TeacherId equals teacher.Id
                        where teacher.FirstName.Contains(request.FirstName) && teacher.LastName.Contains(request.LastName)
                        select subject;

            var distinctSubjects = await query
                .GroupBy(sub => sub.SubjectName)  
                .Select(group => group.First())
                .ToListAsync();

            return distinctSubjects;

        }
    }
}
