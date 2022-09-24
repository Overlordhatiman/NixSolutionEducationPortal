namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDTO> AddCourse(CourseDTO course)
        {
            if (course == null)
            {
                return null;
            }

            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            List<SkillDTO> skills = new List<SkillDTO>();
            for (int i = 0; i < course.MaterialsId.Length; i++)
            {
                materials.Add((await _unitOfWork.MaterialsRepository.GetMaterials(course.MaterialsId[i])).ToDTO());
            }

            for (int i = 0; i < course.SkillsId.Length; i++)
            {
                skills.Add((await _unitOfWork.SkillRepository.GetSkill(course.SkillsId[i])).ToDTO());
            }

            course.Skills = skills;
            course.Materials = materials;

            await _unitOfWork.CourseRepository.AddCourse(course.ToModel(_unitOfWork));

            return course;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var result = await _unitOfWork.CourseRepository.DeleteCourse(id);

            return result != null;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCourse()
        {
            return (await _unitOfWork.CourseRepository.GetAllCourse()).Select(x => x.ToDTO());
        }

        public async Task<CourseDTO> UpdateCourse(CourseDTO course)
        {
            await _unitOfWork.CourseRepository.UpdateCourse(course.ToModel(_unitOfWork));

            return course;
        }

        public async Task<CourseDTO> GetCourse(int id)
        {
            return CourseMapping.ToDTO(await _unitOfWork.CourseRepository.GetCourse(id));
        }
    }
}
