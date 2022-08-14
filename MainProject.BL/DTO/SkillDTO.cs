﻿namespace MainProject.BL.DTO
{
    public class SkillDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int CourseId { get; set; }

        public CourseDTO? Course { get; set; }

        public override string? ToString()
        {
            return Id.ToString() + "\t" + Name + "\t";
        }
    }
}
