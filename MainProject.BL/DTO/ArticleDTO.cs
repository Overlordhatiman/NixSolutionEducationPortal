using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.BL.DTO
{
    public class ArticleDTO : MaterialsDTO
    {
        public DateTime Date { get; set; }
        public string Resource { get; set; }

        public ArticleDTO()
        {

        }
    }
}
