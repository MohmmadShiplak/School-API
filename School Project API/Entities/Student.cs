using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School_Project_API.Entities
{
    
    public class Student
    {

     
        public int Id { get; set; }


        public int CardId { get; set; }

      
        public int DepID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Department? Department { get; set; }

        [JsonIgnore]
        public AccessCard? AccessCard { get; set; }


     //   public ICollection<Subject> Subjects { get; set; }







    }
}
