namespace MainProject.DAL.Repositories.FileRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Newtonsoft.Json;

    public class FileCourseRepository : ICourseRepository
    {
        private List<Course>? _courses;

        public FileCourseRepository()
        {
            string str = File.ReadAllText(DALConstant.CourseFilePath);

            _courses = JsonConvert.DeserializeObject<List<Course>>(str);
        }

        public Course AddCourse(Course course)
        {
            _courses?.Add(course);

            return course;
        }

        public bool DeleteCourse(int id)
        {
            return _courses.Remove(_courses.Find(x => x.Id == id));
        }

        public IEnumerable<Course> GetAllCourse()
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

        public async Task Save()
        {
            var str = JsonConvert.SerializeObject(_courses, Formatting.Indented);

            await File.WriteAllTextAsync(DALConstant.CourseFilePath, str);
        }
    }
}
