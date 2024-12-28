using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Project_API.Data.Config;
using School_Project_API.DTO;
using School_Project_API.Entities;
using System.Runtime.InteropServices;

namespace School_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public DepartmentController(ApplicationDbContext Context)
        {
            _context = Context;
        }


        [HttpGet("{Id}", Name = "GetDepratmentsInfoByID")]

        public async Task<ActionResult<Department>> GetDepratmentsInfoByID(int? Id)
        {


            if (Id < 0)
                return BadRequest($"Departments with {Id} is not Valid ");

            var Department = await _context.Departments.FindAsync(Id);


            if (Department != null)
                return Ok(Department);
            else
                return NotFound($"Deprtmnets with {Id} is not  Found");


        }

        [HttpGet]

        public async Task<ActionResult<Department>> GetAllDepartments()
        {


            var departments = await _context.Departments
    .Select(d => new Department
    {
        Id = d.Id,
        Name = d.Name,

    })
    .ToListAsync();


            return Ok(departments);
        }




        [HttpPost]

        public async Task<ActionResult<Department>> AddDepratments(DepartmentDTO newDepartment)
        {

            if (newDepartment == null)
            {
                return BadRequest("Department data is invalid.");
            }

            // Map DTO to entity (if needed)
            var department = new Department
            {
                Name = newDepartment.Name
                // Add other properties if needed
            };

            // Add the department entity to the context
            _context.Departments.Add(department);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the created department
            return CreatedAtAction("GetDepratmentsInfoByID", new { Id = department.Id }, department);

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<Department>> DeleteDepratment(int Id)
        {

         

                if (Id < 0)
                    return BadRequest($"Departments with {Id} is not Valid ");

            var Department = await _context.Departments.FindAsync(Id);


            if (Department == null)
                return NotFound($"Departments with {Id} is not found ");


            _context.Departments.Remove(Department);


            return Ok(await _context.SaveChangesAsync());


        }


        [HttpPut]
        public async Task<ActionResult<Department>> UpdateDepratment(DepartmentDTO NewDepartment)
        {


            var Department =await _context.Departments.FindAsync(NewDepartment.Id);


            if (Department == null)
                return NotFound("Department not found ");

            Department.Id = NewDepartment.Id;

            Department.Name = NewDepartment.Name;


          await  _context.SaveChangesAsync();

            return Ok(NewDepartment);

        }









    }
}
