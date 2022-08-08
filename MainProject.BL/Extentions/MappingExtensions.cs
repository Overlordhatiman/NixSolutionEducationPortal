namespace MainProject.BL.Extentions
{
    using MainProject.BL.DTO;
    using MainProject.src.Models;

    public static class MappingExtensions
    {
        public static MaterialsDTO ToDTO(this Materials material)
        {
            return new MaterialsDTO
            {
                Id = material.Id,
                Name = material.Name,
            };
        }

        public static Materials ToModel(this MaterialsDTO material)
        {
            return new Materials
            {
                Id = material.Id,
                Name = material.Name,
            };
        }

        public static ArticleDTO ToDTO(this ArticleMaterial articleMaterial)
        {
            return new ArticleDTO
            {
                Id = articleMaterial.Id,
                Date = articleMaterial.Date,
                Name = articleMaterial.Name,
                Resource = articleMaterial.Resource,
            };
        }

        public static ArticleMaterial ToModel(this ArticleDTO article)
        {
            return new ArticleMaterial
            {
                Id = article.Id,
                Date = article.Date,
                Name = article.Name,
                Resource = article.Resource,
            };
        }

        public static VideoDTO ToDTO(this VideoMaterial videoMaterial)
        {
            return new VideoDTO
            {
                Id = videoMaterial.Id,
                Name = videoMaterial.Name,
                Quality = videoMaterial.Quality,
                Time = videoMaterial.Time,
            };
        }

        public static VideoMaterial ToModel(this VideoDTO video)
        {
            return new VideoMaterial
            {
                Id = video.Id,
                Name = video.Name,
                Quality = video.Quality,
                Time = video.Time,
            };
        }

        public static BookDTO ToDTO(this BookMaterial bookMaterial)
        {
            return new BookDTO
            {
                Id = bookMaterial.Id,
                Name = bookMaterial.Name,
                Author = bookMaterial.Author,
                Date = bookMaterial.Date,
                Format = bookMaterial.Format,
                NumberOfPages = bookMaterial.NumberOfPages,
            };
        }

        public static BookMaterial ToModel(this BookDTO book)
        {
            return new BookMaterial
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Date = book.Date,
                Format = book.Format,
                NumberOfPages = book.NumberOfPages,
            };
        }

        public static SkillDTO ToDTO(this Skill skill)
        {
            return new SkillDTO
            {
                Id = skill.Id,
                Name = skill.Name,
            };
        }

        public static Skill ToModel(this SkillDTO skill)
        {
            return new Skill
            {
                Id = skill.Id,
                Name = skill.Name,
            };
        }

        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = user.Password,
            };
        }

        public static User ToModel(this UserDTO user)
        {
            return new User
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = user.Password,
            };
        }

        public static CourseDTO ToDTO(this Course course)
        {
            List<SkillDTO> skills = new List<SkillDTO>();

            foreach (var item in course.Skills)
            {
                skills.Add(ToDTO(item));
            }

            List<MaterialsDTO> materials = new List<MaterialsDTO>();

            foreach (var item in course.Materials)
            {
                if (item is ArticleMaterial)
                {
                    materials.Add(ToDTO((ArticleMaterial)item));
                }

                if (item is VideoMaterial)
                {
                    materials.Add(ToDTO((VideoMaterial)item));
                }

                if (item is BookMaterial)
                {
                    materials.Add(ToDTO((BookMaterial)item));
                }

                if (item is Materials)
                {
                    materials.Add(item.ToDTO());
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
            List<Skill> skills = new List<Skill>();

            foreach (var item in course.Skills)
            {
                skills.Add(ToModel(item));
            }

            List<Materials> materials = new List<Materials>();

            foreach (var item in course.Materials)
            {
                if (item is ArticleDTO)
                {
                    materials.Add(ToModel((ArticleDTO)item));
                }

                if (item is VideoDTO)
                {
                    materials.Add(ToModel((VideoDTO)item));
                }

                if (item is BookDTO)
                {
                    materials.Add(ToModel((BookDTO)item));
                }

                if (item is MaterialsDTO)
                {
                    materials.Add(item.ToModel());
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
