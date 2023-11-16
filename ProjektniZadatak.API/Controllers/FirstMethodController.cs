using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektniZadatak.API.Data;
using ProjektniZadatak.API.Models.Domain;
using ProjektniZadatak.API.Models.DTO;
using ProjektniZadatak.API.Repositories.Interface;

namespace ProjektniZadatak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstMethodController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public FirstMethodController(ApplicationDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }
        



        [HttpPost]
        public async Task<IEnumerable<Student>> SelectStudents(SelectRequestDto request)
        {

            var query = from student in dbContext.Students
                        join teacher in dbContext.Teachers on student.TeacherId equals teacher.Id
                        where teacher.FirstName.Contains(request.FirstName) && teacher.LastName.Contains(request.LastName)
                        select student;
            return await query.ToListAsync();

        }
    }
  
}

