namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class EducationPortalContext : DbContext
    {
        public EducationPortalContext(DbContextOptions<EducationPortalContext> options) : base(options)
        {
        }

        public DbSet<Materials>? Materials { get; set; }

        public DbSet<Skill>? Skills { get; set; }

        public DbSet<User>? Users { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<VideoMaterial>? Videos { get; set; }

        public DbSet<BookMaterial>? Books { get; set; }

        public DbSet<ArticleMaterial>? Articles { get; set; }

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
        }
    }
}
