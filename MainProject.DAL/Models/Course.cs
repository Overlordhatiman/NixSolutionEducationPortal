﻿namespace MainProject.src.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Materials>? Materials { get; set; }

        public List<Skill>? Skills { get; set; }
    }
}
