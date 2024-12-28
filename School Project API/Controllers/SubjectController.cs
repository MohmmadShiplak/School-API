using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Project_API.DTO;
using School_Project_API.Entities;
using System.Text.Json.Serialization;

namespace School_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {

        private readonly ApplicationDbContext _Context;


        public SubjectController(ApplicationDbContext context)
        {
            _Context = context; 
        }


        [HttpGet("{Id}",Name ="GetSubjectsInfoByID")]

        public async Task<ActionResult<Subject>> GetSubjectsInfobyID(int Id)
        {

            var Subject =await _Context.Subjects.FindAsync(Id);


            if (Subject != null)
                return Ok(Subject);
            else
                return NotFound($"No Subjects with SubjectID {Id}");

        }

        [HttpPost(Name ="AddSubjects")]
       public async Task<ActionResult<Subject>>AddSubjects(SubjectDTO NewSubject)
        {




            var Subject = new Subject
            {

                SubjectName = NewSubject.SubjectName,
                Price = NewSubject.Price

            };
          
            

            _Context.Subjects.Add(Subject);

            await _Context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectsInfoByID", new { Id = Subject.Id }, Subject);
        }

        [HttpDelete("{Id}",Name ="DeleteSubject")]

        public async Task<ActionResult<Department>> DeleteSubject(int Id)
        {



            if (Id < 0)
                return BadRequest($"Subjects with {Id} is not Valid ");

            var Subject = await _Context.Subjects.FindAsync(Id);


            if (Subject == null)
                return NotFound($"Subjects with {Id} is not found ");


            _Context.Subjects.Remove(Subject);


            return Ok(await _Context.SaveChangesAsync());


        }

        [HttpGet]
        public async Task <ActionResult<Subject>>GetAllSubjects()
        {

            var Subjects =await  _Context.Subjects
    .Select(x => new Subject
    {
        Id = x.Id,
        SubjectName = x.SubjectName,
      
    })
    .ToListAsync();

            return Ok(Subjects);      

        }




















    }
}
