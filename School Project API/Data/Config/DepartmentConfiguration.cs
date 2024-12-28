using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Project_API.Entities;

namespace School_Project_API.Data.Config
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name)
                .HasMaxLength(250).IsRequired();


            builder.HasData(LoadDepartments());

        }





        private List<Department> LoadDepartments()
        {

            return new List<Department>()
            {

            //new Department { Id = 1,Name="IT" },
            //new Department { Id = 2, Name = "HR" },
            //new Department { Id = 3, Name = "Finance" },
            //new Department { Id = 4, Name = "Marketing" },
            //new Department { Id = 5, Name = "Sales" },
            //new Department { Id = 6, Name = "Operations" },
            //new Department { Id = 7, Name = "Customer Service" },
            //new Department { Id = 8, Name = "Research & Development" },
            //new Department { Id = 9, Name = "Legal" },
            //new Department { Id = 10, Name = "Logistics" }

            };
        }



    }









}

