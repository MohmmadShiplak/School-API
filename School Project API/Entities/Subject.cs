using System.Text.Json.Serialization;

namespace School_Project_API.Entities
{
    public class Subject
    {

        public int Id { get; set; } 

        public string ?SubjectName { get; set; }    


        public decimal Price { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; }




    }
}
