using Microsoft.EntityFrameworkCore;
using WebApp.DataAcces.Configurations;
using WebApp.DataAcces.Entities;

namespace WebApp.DataAcces
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Video> TrainingVideo { get; set; }
        public DbSet<Results> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionsConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
            modelBuilder.ApplyConfiguration(new ResultsConfiguration());
        }
    }
}
