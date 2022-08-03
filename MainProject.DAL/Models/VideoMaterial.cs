using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.src.Models
{
    public class VideoMaterial : Materials
    {
        public int Time { get; set; }
        public string Quality { get; set; }

        public VideoMaterial()
        {

        }

        public VideoMaterial(int id, int time, string quality, string name) : base(name)
        {
            Id = id;
            Time = time;
            Quality = quality;
        }
    }
}
