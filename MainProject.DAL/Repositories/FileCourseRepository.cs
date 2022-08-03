using MainProject.DAL.Interfaces;
using MainProject.src.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Repositories
{
    public class FileCourseRepository : ICourseRepository
    {
        private List<Course> _courses;
        public FileCourseRepository()
        {
            string str = File.ReadAllText(DALConstant.CourseFilePath);

            _courses = JsonConvert.DeserializeObject<List<Course>>(str);
        }

        public Course AddCourse(Course course)
        {
            _courses.Add(course);

            return course;
        }

        public bool DeleteCourse(Course course)
        {
            return _courses.Remove(course);
        }

        public List<Course> GetAllCourse()
        {
            return _courses;
        }

        public Course UpdateCourse(int id, Course course)
        {
            int index = _courses.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return new Course();
            }

            _courses[index] = course;

            return course;
        }

        public void Save()
        {
            var str = JsonConvert.SerializeObject(_courses, Formatting.Indented);

            File.WriteAllText(DALConstant.CourseFilePath, str);
        }
    }
}
