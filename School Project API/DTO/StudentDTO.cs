namespace School_Project_API.DTO
{
    public class StudentDTO
    {

        public int Id { get; set; }

        public int CardID { get; set; }

        public int DepID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
