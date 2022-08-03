using MainProject.BL.DTO;
using MainProject.BL.Extentions;
using MainProject.BL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.UI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var temp = new ServiceCollection();
            temp.AddServices();

            var services = temp.BuildServiceProvider();

            services.GetRequiredService<IUserService>().AddUser(new UserDTO
            {
                Id = 0,
                Mail = "mail",
                Password = "pass"
            });
        }
    }
}
