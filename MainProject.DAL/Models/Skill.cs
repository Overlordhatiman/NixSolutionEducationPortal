using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.src.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Skill()
        {

        }
        public Skill(int id, string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id;
        }
    }
}
