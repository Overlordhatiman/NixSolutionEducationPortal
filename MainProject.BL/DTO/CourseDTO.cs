using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.BL.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MaterialsDTO> Materials { get; set; }
        public List<SkillDTO> Skills { get; set; }

        public CourseDTO()
        {

        }
    }
}
