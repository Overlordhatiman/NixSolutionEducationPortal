using MainProject.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface ICourseRepository
    {
        public Course AddCourse(Course course);
        public Course UpdateCourse(int id, Course course);
        public List<Course> GetAllCourse();
        public bool DeleteCourse(Course course);
    }
}
