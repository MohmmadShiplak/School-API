using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using School_Project_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {


        builder.HasKey(S => S.Id);


        builder.Property(S => S.FirstName)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(S => S.LastName)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasOne(s => s.AccessCard)
            .WithOne(s => s.Student)
            .HasForeignKey<Student>(x => x.CardId);



        builder.HasOne(x => x.Department)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.DepID);



        //builder.HasMany(s => s.Subjects)
        //         .WithMany(x => x.Students)
        //          .UsingEntity<StudentSubjects>();




        //builder.Property(S => S.DateOfBirth);


        builder.ToTable("Students");

        builder.HasData(LoadStudents());


        }

    private static List<Student> LoadStudents()
    {
        return new List<Student>
            {
                //new Student{ Id = 1, FirstName = "Mohmmad", LastName="Shiplak",DateOfBirth= new DateTime(2003,3,3),CardId=1,DepID=1},
                //new Student { Id = 2, FirstName = "Ahmad", LastName="Salamat",DateOfBirth= new DateTime(2001,2,3),CardId=2,DepID=2},
                //new Student{ Id = 3, FirstName = "Fadi", LastName="Bani Younes", DateOfBirth = new DateTime(2000, 4, 3), CardId = 3, DepID = 3},
                //new Student{Id = 4, FirstName = "Hamza", LastName="haj ali" ,DateOfBirth= new DateTime(1990,8,3), CardId = 4,DepID = 4},
     
            };
    }















}

