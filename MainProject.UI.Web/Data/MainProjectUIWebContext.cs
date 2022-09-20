using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MainProject.BL.DTO;

namespace MainProject.UI.Web.Data
{
    public class MainProjectUIWebContext : DbContext
    {
        public MainProjectUIWebContext (DbContextOptions<MainProjectUIWebContext> options)
            : base(options)
        {
        }

        public DbSet<MainProject.BL.DTO.SkillDTO> SkillDTO { get; set; } = default!;

        public DbSet<MainProject.BL.DTO.ArticleDTO> ArticleDTO { get; set; }

        public DbSet<MainProject.BL.DTO.BookDTO> BookDTO { get; set; }

        public DbSet<MainProject.BL.DTO.VideoDTO> VideoDTO { get; set; }

        public DbSet<MainProject.BL.DTO.MaterialsDTO> MaterialsDTO { get; set; }

        public DbSet<MainProject.BL.DTO.CourseDTO> CourseDTO { get; set; }

        public DbSet<MainProject.BL.DTO.UserDTO> UserDTO { get; set; }

        public DbSet<MainProject.BL.DTO.UserCourseDTO> UserCourseDTO { get; set; }

        public DbSet<MainProject.BL.DTO.UserSkillDTO> UserSkillDTO { get; set; }
    }
}
