using System.Text.Json.Serialization;

namespace School_Project_API.Entities
{
    public class Department
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();


    }
}
