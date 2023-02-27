using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.DataAcces.Entities;

namespace WebApp.DataAcces.Configurations
{
    public class ResultsConfiguration : IEntityTypeConfiguration<Results>
    {
        public void Configure(EntityTypeBuilder<Results> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Results");

            entity.Property(e => e.Id)
                .HasColumnName("Result_Id");

            entity.Property(e => e.AssignmentId)
                .HasColumnName("Assignment_Id");

            entity.Property(e => e.StudentId)
                .HasColumnName("Student_Id");

            entity.Property(e => e.PassMark)
                .HasColumnName("PassMark");

            entity.Property(e => e.Marks)
                .HasColumnName("Marks");
        }
    }
}
