using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainProject.BL.DTO;
using MainProject.BL.Interfaces;

namespace MainProject.UI.Web.Controllers
{
    public class SkillDTOesController : Controller
    {
        private readonly ISkillService skillService;

        public SkillDTOesController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        // GET: SkillDTOes
        public async Task<IActionResult> Index()
        {
              return View(await skillService.GetAllSkill());
        }

        // GET: SkillDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDTO = await skillService.GetSkill((int)id);
            if (skillDTO == null)
            {
                return NotFound();
            }

            return View(skillDTO);
        }

        // GET: SkillDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillDTOes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SkillDTO skillDTO)
        {
            if (ModelState.IsValid)
            {
                skillService.AddSkill(skillDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(skillDTO);
        }

        // GET: SkillDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDTO = await skillService.GetSkill((int)id);
            if (skillDTO == null)
            {
                return NotFound();
            }
            return View(skillDTO);
        }

        // POST: SkillDTOes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SkillDTO skillDTO)
        {
            if (skillDTO == null)
            {
                return NotFound();
            }

            if (id != skillDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    skillService.UpdateSkill(skillDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillDTOExists(skillDTO.Id))
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
            return View(skillDTO);
        }

        // GET: SkillDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDTO = await skillService.GetSkill((int)id);
            if (skillDTO == null)
            {
                return NotFound();
            }

            return View(skillDTO);
        }

        // POST: SkillDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            skillService.DeleteSkill(id);
                        
            return RedirectToAction(nameof(Index));
        }

        private bool SkillDTOExists(int id)
        {
          return skillService.GetSkill(id) == null;
        }
    }
}
