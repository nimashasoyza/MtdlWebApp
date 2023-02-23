using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DataAcces.Models;

namespace WebApp.DataAcces.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            entity.Property(e => e.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(10);

            entity.Property(e => e.Password)
                .HasColumnName("Password");

            entity.Property(e => e.IsActive)
                .HasColumnName("IsActive");
        }
    }
}
