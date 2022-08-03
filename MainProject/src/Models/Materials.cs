using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.src.Models
{
    abstract public class Materials
    {
        int Id { get; set; }
        string Name { get; set; }

        public Materials(string name)
        {
            Name = name;
        }
    }
}
