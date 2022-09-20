using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainProject.BL.DTO;
using MainProject.UI.Web.Data;

namespace MainProject.UI.Web.Controllers
{
    public class UserCourseDTOesController : Controller
    {
        private readonly MainProjectUIWebContext _context;

        public UserCourseDTOesController(MainProjectUIWebContext context)
        {
            _context = context;
        }

        // GET: UserCourseDTOes
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserCourseDTO.ToListAsync());
        }

        // GET: UserCourseDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserCourseDTO == null)
            {
                return NotFound();
            }

            var userCourseDTO = await _context.UserCourseDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCourseDTO == null)
            {
                return NotFound();
            }

            return View(userCourseDTO);
        }

        // GET: UserCourseDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserCourseDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsFinished,Percent")] UserCourseDTO userCourseDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCourseDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userCourseDTO);
        }

        // GET: UserCourseDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserCourseDTO == null)
            {
                return NotFound();
            }

            var userCourseDTO = await _context.UserCourseDTO.FindAsync(id);
            if (userCourseDTO == null)
            {
                return NotFound();
            }
            return View(userCourseDTO);
        }

        // POST: UserCourseDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsFinished,Percent")] UserCourseDTO userCourseDTO)
        {
            if (userCourseDTO == null)
            {
                return NotFound();
            }

            if (id != userCourseDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCourseDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCourseDTOExists(userCourseDTO.Id))
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
            return View(userCourseDTO);
        }

        // GET: UserCourseDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserCourseDTO == null)
            {
                return NotFound();
            }

            var userCourseDTO = await _context.UserCourseDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCourseDTO == null)
            {
                return NotFound();
            }

            return View(userCourseDTO);
        }

        // POST: UserCourseDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserCourseDTO == null)
            {
                return Problem("Entity set 'MainProjectUIWebContext.UserCourseDTO'  is null.");
            }
            var userCourseDTO = await _context.UserCourseDTO.FindAsync(id);
            if (userCourseDTO != null)
            {
                _context.UserCourseDTO.Remove(userCourseDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCourseDTOExists(int id)
        {
          return _context.UserCourseDTO.Any(e => e.Id == id);
        }
    }
}
