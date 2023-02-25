using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.DataAcces.Entities;

namespace WebApp.DataAcces.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Assignment");

            entity.Property(e => e.Id)
                .HasColumnName("Assignment_Id");

            entity.Property(e => e.VideoId)
                .HasColumnName("Assignment_VideoId");

            entity.Property(e => e.Title)
                .HasColumnName("Assignment_Title")
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasColumnName("Assignment_Description")
                .HasMaxLength(200);

            entity.Property(e => e.PassMark)
                .HasColumnName("Assignment_PassMark");

            entity.Property(e => e.UserId)
                .HasColumnName("Assignment_UserId");
        }
    }
}
