using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.src.Models
{
    public class ArticleMaterial : Materials
    {
        public DateTime Date { get; set; }
        public string Resource { get; set; }

        public ArticleMaterial()
        {

        }

        public ArticleMaterial(int id, DateTime date, string resource, string name) : base(name)
        {
            Id = id;
            Date = date;
            Resource = resource ?? throw new ArgumentNullException(nameof(resource));
        }

    }
}
