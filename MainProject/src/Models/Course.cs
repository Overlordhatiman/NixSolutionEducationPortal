using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.src.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Materials> Materials { get; set; }
        public List<Skill> Skills { get; set; }

        public Course(string name, string description, List<Materials> materials, List<Skill> skills)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            this.Materials = materials ?? throw new ArgumentNullException(nameof(materials));
            this.Skills = skills ?? throw new ArgumentNullException(nameof(skills));
        }
    }
}
