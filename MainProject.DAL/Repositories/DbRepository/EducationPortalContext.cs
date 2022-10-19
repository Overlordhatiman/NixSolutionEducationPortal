namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.Reflection;

    public class EducationPortalContext : DbContext
    {
        public EducationPortalContext(DbContextOptions<EducationPortalContext> options) : base(options)
        {
        }

        public DbSet<Materials>? Materials { get; set; }

        public DbSet<Skill>? Skills { get; set; }

        public DbSet<User>? Users { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<UserSkill>? UserSkills { get; set; }

        public DbSet<UserCourse>? UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Materials>().ToTable("Materials").HasDiscriminator("Discriminator", typeof(string));
            modelBuilder.Entity<ArticleMaterial>();
            modelBuilder.Entity<VideoMaterial>();
            modelBuilder.Entity<BookMaterial>();
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<UserSkill>().ToTable("UserSkills");
            modelBuilder.Entity<UserCourse>().ToTable("UserCourses");
        }
    }
}
