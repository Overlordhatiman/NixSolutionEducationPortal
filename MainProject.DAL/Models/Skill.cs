﻿namespace MainProject.DAL.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Course>? Courses { get; set; } = new List<Course>();

        public List<UserSkill>? UserSkills { get; set; } = new List<UserSkill>();
    }
}
