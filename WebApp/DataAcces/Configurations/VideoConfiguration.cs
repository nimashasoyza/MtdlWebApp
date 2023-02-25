using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.DataAcces.Entities;

namespace WebApp.DataAcces.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TrainingVideo");

            entity.Property(e => e.Id)
                .HasColumnName("Video_Id");

            entity.Property(e => e.Title)
                .HasColumnName("Video_Title")
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasColumnName("Video_Description")
                .HasMaxLength(1000);

            entity.Property(e => e.UploadPath)
                .HasColumnName("Video_UploadPath")
                .HasMaxLength(200);

            entity.Property(e => e.UserId)
                .HasColumnName("Video_UserId");
        }
    }
}
