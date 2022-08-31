namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class UserCourseMapping
    {
        public static UserCourseDTO ToDTO(this UserCourse userCourse)
        {
            if (userCourse == null)
            {
                return new UserCourseDTO();
            }

            return new UserCourseDTO
            {
                Id = userCourse.Id,
                IsFinished = userCourse.IsFinished,
                Percent = userCourse.Percent,
                Course = userCourse.Course.ToDTO(),
                User = userCourse.User.ToDTO(),
            };
        }

        public static UserCourse ToModel(this UserCourseDTO userCourse)
        {
            if (userCourse == null)
            {
                return new UserCourse();
            }

            return new UserCourse
            {
                Id = userCourse.Id,
                IsFinished = userCourse.IsFinished,
                Percent = userCourse.Percent,
                Course = userCourse.Course.ToModel(),
                User = userCourse.User.ToModel(),
            };
        }
    }
}
