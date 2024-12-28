using System.ComponentModel.DataAnnotations.Schema;

namespace School_Project_API.Entities
{
    public class StudentSubjects
    {

        public int Id { get; set; }

        [Column("StudentId")]
        public int StudentId { get; set; }

        public Student Student { get; set; }
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
        public DateTime StartDate { get; set; }


    }
}
