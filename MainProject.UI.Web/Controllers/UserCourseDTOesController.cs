using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainProject.BL.DTO;
using MainProject.BL.Interfaces;

namespace MainProject.UI.Web.Controllers
{
    public class UserCourseDTOesController : Controller
    {
        private readonly IUserCourse userCourseService;
        private readonly IUserService userService;
        private readonly ICourseService courseService;

        public UserCourseDTOesController(IUserCourse service, IUserService userService, ICourseService courseService)
        {
            userCourseService = service;
            this.userService = userService;
            this.courseService = courseService;
        }

        // GET: UserCourseDTOes
        public async Task<IActionResult> Index()
        {
            var user = await userService.GetUser(User.Identity.Name);
            return View(await userCourseService.GetUserCourseForUser(user));
        }

        // GET: UserCourseDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourseDTO = await userCourseService.GetUserCourse((int)id);
            if (userCourseDTO == null)
            {
                return NotFound();
            }

            return View(userCourseDTO);
        }

        // GET: UserCourseDTOes/Create
        public async Task<IActionResult> Create(int id)
        {
            UserCourseDTO userCourseDTO = new UserCourseDTO
            {
                Course = await courseService.GetCourse(id),
                User = await userService.GetUser(User.Identity.Name)
            };
            await userCourseService.AddUserCourse(userCourseDTO);
            await userCourseService.CheckSkills(userCourseDTO.Course.Id, userCourseDTO.User.Id);

            return RedirectToAction(nameof(StartedCourses));
        }

        // GET: UserCourseDTOes/StartedCourses
        public async Task<IActionResult> StartedCourses()
        {
            var user = await userService.GetUser(User.Identity.Name);
            var coursesInDb = await courseService.GetAllCourse();
            var startedCourses = await userCourseService.GetUserCourseForUser(user.Id);

            List<CourseDTO> courses = new List<CourseDTO>();
            foreach (var course in startedCourses)
            {
                var item = coursesInDb.FirstOrDefault(x => x.Id == course.Course.Id);
                if (item != null)
                {
                    courses.Add(item);
                }
            }

            return View(courses);
        }

        public async Task<IActionResult> FinishMaterials(int? id)
        {
            CourseDTO course;
            if (id != null)
            {
                course = await courseService.GetCourse((int)id);
                List<bool> materials = new List<bool>();
                var user = await userService.GetUser(User.Identity.Name);

                foreach (var material in course.Materials)
                {
                    if (user.Materials.Where(m => m.Id == material.Id).Count() == 0)
                    {
                        materials.Add(false);
                    }
                    else
                    {
                        materials.Add(true);
                    }
                }

                ViewBag.Materials = materials;
                return View(course);
            }

            return NotFound();
        }

        // GET: UserCourseDTOes/PasMaterial/5
        public async Task<IActionResult> PassMaterial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userService.GetUser(User.Identity.Name);
            await userCourseService.FinishMaterial((int)id, user);

            return RedirectToAction("StartedCourses");
        }
    }
}
