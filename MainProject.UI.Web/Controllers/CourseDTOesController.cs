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
    public class CourseDTOesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IMaterialsService materialsService;
        private readonly ISkillService skillService;

        public CourseDTOesController(ICourseService service, IMaterialsService materialsService, ISkillService skillService)
        {
            courseService = service;
            this.materialsService = materialsService;
            this.skillService = skillService;
        }

        // GET: CourseDTOes
        public async Task<IActionResult> Index()
        {
              return View(await courseService.GetAllCourse());
        }

        // GET: CourseDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDTO = await courseService.GetCourse((int)id);
            if (courseDTO == null)
            {
                return NotFound();
            }

            return View(courseDTO);
        }

        // GET: CourseDTOes/Create
        public async Task<IActionResult> Create()
        {
            var materials = await materialsService.GetAllMaterial();
            ViewBag.MaterialsId = new SelectList(materials, "Id", "Name");

            var skills = await skillService.GetAllSkill();
            ViewBag.SkillsId = new SelectList(skills, "Id", "Name");

            return View();
        }

        // POST: CourseDTOes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,MaterialsId,SkillsId")] CourseDTO courseDTO)
        {
            if (ModelState.IsValid)
            {
                await courseService.AddCourse(courseDTO);
                return RedirectToAction(nameof(Index));
            }

            if (courseDTO != null)
            {
                var skills = await skillService.GetAllSkill();
                var materials = await materialsService.GetAllMaterial();
                ViewBag.MaterialsId = new SelectList(materials, "Id", "Name", courseDTO.MaterialsId);
                ViewBag.SkillsId = new SelectList(skills, "Id", "Name", courseDTO.SkillsId);
            }

            return View(courseDTO);
        }

        // GET: CourseDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDTO = await courseService.GetCourse((int)id);
            if (courseDTO == null)
            {
                return NotFound();
            }
            return View(courseDTO);
        }

        // POST: CourseDTOes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] CourseDTO courseDTO)
        {
            if (courseDTO == null)
            {
                return NotFound();
            }

            if (id != courseDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    courseService.UpdateCourse(courseDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseDTOExists(courseDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(courseDTO);
        }

        // GET: CourseDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDTO = await courseService.GetCourse((int)id);
            if (courseDTO == null)
            {
                return NotFound();
            }

            return View(courseDTO);
        }

        // POST: CourseDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseDTOExists(int id)
        {
          return courseService.GetCourse(id) == null;
        }
    }
}
