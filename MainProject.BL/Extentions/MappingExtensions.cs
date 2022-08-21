﻿namespace MainProject.BL.Extentions
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class MappingExtensions
    {
        public static MaterialsDTO ToDTO(this Materials material)
        {
            if (material == null)
            {
                return new MaterialsDTO();
            }

            MaterialsDTO materials = new MaterialsDTO
            {
                Id = material.Id,
                Name = material.Name,
            };

            if (material is ArticleMaterial article)
            {
                materials = new ArticleDTO
                {
                    Id = article.Id,
                    Name = article.Name,
                    Date = article.Date,
                    Resource = article.Resource,
                };
            }

            if (material is BookMaterial book)
            {
                materials = new BookDTO
                {
                    Id = book.Id,
                    Author = book.Author,
                    Date = book.Date,
                    Format = book.Format,
                    NumberOfPages = book.NumberOfPages,
                    Name = book.Name,
                };
            }

            if (material is VideoMaterial video)
            {
                materials = new VideoDTO
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Time = video.Time,
                };
            }

            return materials;
        }

        public static Materials ToModel(this MaterialsDTO material)
        {
            if (material == null)
            {
                return new Materials();
            }

            Materials materials = new Materials
            {
                Id = material.Id,
                Name = material.Name,
            };

            if (material is ArticleDTO article)
            {
                materials = new ArticleMaterial
                {
                    Id = article.Id,
                    Name = article.Name,
                    Date = article.Date,
                    Resource = article.Resource,
                };
            }

            if (material is BookDTO book)
            {
                materials = new BookMaterial
                {
                    Id = book.Id,
                    Author = book.Author,
                    Date = book.Date,
                    Format = book.Format,
                    NumberOfPages = book.NumberOfPages,
                    Name = book.Name,
                };
            }

            if (material is VideoDTO video)
            {
                materials = new VideoMaterial
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Time = video.Time,
                };
            }

            return materials;
        }

        public static ArticleDTO ToDTO(this ArticleMaterial articleMaterial)
        {
            if (articleMaterial == null)
            {
                return new ArticleDTO();
            }

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
            if (article == null)
            {
                return new ArticleMaterial();
            }

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
            if (videoMaterial == null)
            {
                return new VideoDTO();
            }

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
            if (video == null)
            {
                return new VideoMaterial();
            }

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
            if (bookMaterial == null)
            {
                return new BookDTO();
            }

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
            if (book == null)
            {
                return new BookMaterial();
            }

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
            if (skill == null)
            {
                return new SkillDTO();
            }

            SkillDTO skillDTO = new SkillDTO
            {
                Id = skill.Id,
                Name = skill.Name,
            };

            return skillDTO;
        }

        public static Skill ToModel(this SkillDTO skill)
        {
            if (skill == null)
            {
                return new Skill();
            }

            Skill skillModel = new Skill
            {
                Id = skill.Id,
                Name = skill.Name,
            };

            return skillModel;
        }

        public static UserDTO ToDTO(this User user)
        {
            if (user == null)
            {
                return new UserDTO();
            }

            return new UserDTO
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = user.Password,
            };
        }

        public static User ToModel(this UserDTO user)
        {
            if (user == null)
            {
                return new User();
            }

            return new User
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = user.Password,
            };
        }

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
                    skills.Add(ToDTO(skill));
                }
            }

            List<MaterialsDTO> materials = new List<MaterialsDTO>();

            foreach (var material in course.Materials)
            {
                if (material is ArticleMaterial article)
                {
                    materials.Add(ToDTO(article));
                }

                if (material is VideoMaterial video)
                {
                    materials.Add(ToDTO(video));
                }

                if (material is BookMaterial book)
                {
                    materials.Add(ToDTO(book));
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
                    skills.Add(ToModel(skill));
                }
            }

            List<Materials> materials = new List<Materials>();

            foreach (var material in course.Materials)
            {
                if (material is ArticleDTO article)
                {
                    materials.Add(ToModel(article));
                }

                if (material is VideoDTO video)
                {
                    materials.Add(ToModel(video));
                }

                if (material is BookDTO book)
                {
                    materials.Add(ToModel(book));
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
