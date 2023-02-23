using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DataAcces.Entities;

namespace WebApp.DataAcces.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Users");

            entity.Property(e => e.Id)
                .HasColumnName("User_Id");

            entity.Property(e => e.UserName)
                .HasColumnName("User_Name")
                .HasMaxLength(200);

            entity.Property(e => e.Password)
                .HasColumnName("User_Password")
                .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                .HasColumnName("User_IsActive");

            entity.Property(e => e.RoleId)
                .HasColumnName("User_RoleId");

            entity.Property(e => e.FirstName)
                .HasColumnName("User_FirstName")
                .HasMaxLength(200);

            entity.Property(e => e.LastName)
                .HasColumnName("User_LastName")
                .HasMaxLength(200);

            entity.Property(e => e.Hospital)
                .HasColumnName("User_Hospital")
                .HasMaxLength(100);

            entity.Property(e => e.RegistrationNumber)
                .HasColumnName("User_RegNumber")
                .HasMaxLength(100);

            entity.Property(e => e.Address)
                .HasColumnName("User_Address")
                .HasMaxLength(100);

            entity.Property(e => e.Address2)
                .HasColumnName("User_Address2")
                .HasMaxLength(100);

            entity.Property(e => e.City)
                .HasColumnName("User_City")
                .HasMaxLength(100);

            entity.Property(e => e.State)
                .HasColumnName("User_State")
                .HasMaxLength(100);

            entity.Property(e => e.PostalCode)
                .HasColumnName("User_PostalCode")
                .HasMaxLength(50);

            entity.Property(e => e.MobileNumber)
               .HasColumnName("User_MobileNumber")
               .HasMaxLength(12);

            entity.Property(e => e.Landline)
                .HasColumnName("User_Landline")
                .HasMaxLength(12);
        }
    }
}
