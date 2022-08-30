namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class CourseMapping
    {
        public static CourseDTO ToDTO(this Course course)
        {
            if (course == null)
            {
                return new CourseDTO();
            }

            List<SkillDTO> skills = new List<SkillDTO>();

            foreach (var skill in course.Skills)
            {
                if (skill != null)
                {
                    skills.Add(SkillMapping.ToDTO(skill));
                }
            }

            List<MaterialsDTO> materials = new List<MaterialsDTO>();

            foreach (var material in course.Materials)
            {
                if (material is ArticleMaterial article)
                {
                    materials.Add(ArticleMapping.ToDTO(article));
                }

                if (material is VideoMaterial video)
                {
                    materials.Add(VideoMapping.ToDTO(video));
                }

                if (material is BookMaterial book)
                {
                    materials.Add(BookMapping.ToDTO(book));
                }
            }

            return new CourseDTO
            {
                Id = course.Id,
                Description = course.Description,
                Name = course.Name,
                Skills = skills,
                Materials = materials,
            };
        }

        public static Course ToModel(this CourseDTO course)
        {
            if (course == null)
            {
                return new Course();
            }

            List<Skill> skills = new List<Skill>();

            foreach (var skill in course.Skills)
            {
                if (skill != null)
                {
                    skills.Add(SkillMapping.ToModel(skill));
                }
            }

            List<Materials> materials = new List<Materials>();

            foreach (var material in course.Materials)
            {
                if (material is ArticleDTO article)
                {
                    materials.Add(ArticleMapping.ToModel(article));
                }

                if (material is VideoDTO video)
                {
                    materials.Add(VideoMapping.ToModel(video));
                }

                if (material is BookDTO book)
                {
                    materials.Add(BookMapping.ToModel(book));
                }
            }

            return new Course
            {
                Id = course.Id,
                Description = course.Description,
                Name = course.Name,
                Skills = skills,
                Materials = materials,
            };
        }
    }
}
