using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Project_API.DTO;
using School_Project_API.Entities;

namespace School_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessCardController : ControllerBase
    {

        private readonly ApplicationDbContext _Context;

        public AccessCardController(ApplicationDbContext context)
        {
            _Context = context;
        }

        [HttpPost]

        public async Task<ActionResult<AccessCard>> AddAccessCards(AccessCardDTO NewAccessCard)
        {

            var AccessCards = new AccessCard
            {

                SerialNo = NewAccessCard.SerialNo,
                ExpirationDate = NewAccessCard.ExpirationDate


            };

            _Context.AccessCards.Add(AccessCards);


            await _Context.SaveChangesAsync();

         return Ok(AccessCards);

        }

        [HttpGet]
        public async Task<ActionResult<AccessCard>> GetAllAccessCards()
        {

            var Accesscadrs = await _Context.AccessCards.Select(A => new
            AccessCard
            {

                Id = A.Id,
                SerialNo = A.SerialNo,
                ExpirationDate= A.ExpirationDate    


            }).ToListAsync(); 
             
             return Ok(Accesscadrs);    
        }

        [HttpPut]

        public async Task<ActionResult<AccessCard>> UpdateAccessCards(AccessCardDTO UpdatedAcccessCard)
        {

          var AccessCards = await _Context.AccessCards.FindAsync(UpdatedAcccessCard.Id);   


           
            AccessCards.Id= UpdatedAcccessCard.Id;  
            AccessCards.SerialNo= UpdatedAcccessCard.SerialNo;  
            AccessCards.ExpirationDate= UpdatedAcccessCard.ExpirationDate;


          await  _Context.SaveChangesAsync();

        return Ok(UpdatedAcccessCard);
        }



        [HttpDelete("{Id}")]
        public async Task<ActionResult<AccessCard>>DeleteAccessCard(int Id)
        {
            if (Id < 0)
                return BadRequest($"AccessCards with {Id} is not Valid ");

            var AccessCard = await _Context.AccessCards.FindAsync(Id);


            if (AccessCard == null)
                return NotFound($"AccessCards with {Id} is not found ");


            _Context.AccessCards.Remove(AccessCard);


            return Ok(await _Context.SaveChangesAsync());


        }















    }











}
