using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.src.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public User(int id, string mail, string password)
        {
            Id = id;
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}
