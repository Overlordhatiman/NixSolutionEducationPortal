using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.BL.DTO
{
    public class VideoDTO : MaterialsDTO
    {
        public int Time { get; set; }
        public string Quality { get; set; }

        public VideoDTO()
        {

        }
    }
}
