﻿namespace MainProject.BL.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public int[] MaterialsId { get; set; }

        public int[] SkillsId { get; set; }

        public IEnumerable<MaterialsDTO>? Materials { get; set; }

        public IEnumerable<SkillDTO>? Skills { get; set; }

        public override string? ToString()
        {
            string result = string.Empty;

            result = Name + "\t" + Description + "\n";

            result += "Materials:\n";

            foreach (var material in Materials)
            {
                result += material.ToString() + "\t";
            }

            result += "\n";

            result += "Skills:\n";

            foreach (var skill in Skills)
            {
                result += skill.ToString() + "\t";
            }

            return result;
        }
    }
}
