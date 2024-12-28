using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Project_API.DTO;
using School_Project_API.Entities;

namespace School_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ApplicationDbContext _Context;

        public StudentController(ApplicationDbContext context)
        {
            _Context = context;
        }



        [HttpGet("{Id}", Name = "GetStudentsInfoByID")]

        public async Task<ActionResult<Student>> GetStudentsInfoByID(int Id)
        {


            if (Id < 0)
                return BadRequest($"Students with {Id} is not Valid ");

            var Student = await _Context.Students.Include(s => s.AccessCard).
                FirstOrDefaultAsync(s => s.Id == Id);


            if (Student != null)
                return Ok(Student);
            else
                return NotFound($"Students with {Id} is not  Found");


        }

        [HttpGet]
        public async Task<ActionResult<Student>> GetAllStudents()
        {
            var Students = await _Context.Students
    .Include(d => d.AccessCard) // Corrected .Include() syntax
    .Select(d => new Student
    {
        Id = d.Id,
        FirstName = d.FirstName,
        LastName = d.LastName,
        DateOfBirth = d.DateOfBirth,
        CardId = d.CardId,
        DepID = d.DepID,
        AccessCard = d.AccessCard,
        Department = d.Department


    })


    .ToListAsync();



            return Ok(Students);
        }



        /*
         
        in this case 


        it is so significant to create a  DTO in order to send required information to server 

        and void unNecessary information 


        */


        [HttpPost(Name = "AddStudents")]
        public async Task<ActionResult<StudentDTO>> AddStudents(StudentDTO student)
        {

            var Department = await _Context.Departments.FindAsync(student.DepID);

            var Accesscard = await _Context.AccessCards.FindAsync(student.CardID);


            if (student == null)
                return NotFound("Invalid Students Data");


            var NewStudent = new Student
            {
                CardId = student.CardID,
                DepID = student.DepID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Department = Department,
                AccessCard = Accesscard



            };


            _Context.Students.Add(NewStudent);

            await _Context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsInfoByID", new { Id = student.CardID, }, student);


        }

        [HttpPut]
        public async Task<ActionResult<List<StudentDTO>>> UpdateStudents(StudentDTO updateStudent)
        {

            if (updateStudent == null)
                return BadRequest("Student data is null");

            // Assuming DepID is a unique identifier for a student
            var student = await _Context.Students.FindAsync(updateStudent.Id);

            if (student == null)
                return NotFound("Student not found");

            student.CardId = updateStudent.CardID;
            student.DepID = updateStudent.DepID;
            student.FirstName = updateStudent.FirstName;
            student.LastName = updateStudent.LastName;
            student.DateOfBirth = updateStudent.DateOfBirth;

            // Save changes and get the updated student
            await _Context.SaveChangesAsync();

  

            // Return the updated student DTO, maybe with additional transformations
            return Ok(student);



        }
    }
}