﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School_Project_API.Entities;

namespace School_Project_API.Data.Config
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {

            builder.HasKey(s => s.Id);

            // Configure SubjectName to be required with a maximum length of 100 characters
            builder.Property(s => s.SubjectName)
                   .IsRequired(false) // allows null, since it's nullable
                   .HasMaxLength(100); // maximum length for the string

            // Configure Price with a precision of 18 and scale of 2
            builder.Property(s => s.Price)
                   .HasColumnType("decimal(18,2)"); // 

        }


    
    
    









    }
}
