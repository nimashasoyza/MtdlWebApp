using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.DataAcces.Entities;

namespace WebApp.DataAcces.Configurations
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Questions");

            entity.Property(e => e.Id)
                .HasColumnName("Question_Id");

            entity.Property(e => e.Question)
                .HasColumnName("question")
                .HasMaxLength(500);

            entity.Property(e => e.TrueAnswer)
                .HasColumnName("TrueAnswer")
                .HasMaxLength(500);

            entity.Property(e => e.FalseAnswer1)
                .HasColumnName("FalseAnswer1");

            entity.Property(e => e.FalseAnswer2)
                .HasColumnName("FalseAnswer2");

            entity.Property(e => e.FalseAnswer3)
                .HasColumnName("FalseAnswer3")
                .HasMaxLength(200);

            entity.Property(e => e.AssignmentId)
                .HasColumnName("Assignment_Id")
                .HasMaxLength(200);
        }
    }
}
