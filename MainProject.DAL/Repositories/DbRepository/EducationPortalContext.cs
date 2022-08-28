namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class EducationPortalContext : DbContext
    {
        public DbSet<Materials>? Materials { get; set; }

        public DbSet<Skill>? Skills { get; set; }

        public DbSet<User>? Users { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<VideoMaterial>? Videos { get; set; }

        public DbSet<BookMaterial>? Books { get; set; }

        public DbSet<ArticleMaterial>? Articles { get; set; }

        public DbSet<UserSkill>? UserSkills { get; set; }

        public DbSet<UserCourse>? UserCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                return;
            }

            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false);
                IConfiguration config = builder.Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Materials>().ToTable("Materials");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<UserSkill>().ToTable("UserSkills");
            modelBuilder.Entity<UserCourse>().ToTable("UserCourses");
        }
    }
}
