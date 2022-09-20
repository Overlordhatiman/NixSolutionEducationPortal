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
    public class VideoDTOesController : Controller
    {
        private readonly MainProjectUIWebContext _context;

        public VideoDTOesController(MainProjectUIWebContext context)
        {
            _context = context;
        }

        // GET: VideoDTOes
        public async Task<IActionResult> Index()
        {
              return View(await _context.VideoDTO.ToListAsync());
        }

        // GET: VideoDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VideoDTO == null)
            {
                return NotFound();
            }

            var videoDTO = await _context.VideoDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoDTO == null)
            {
                return NotFound();
            }

            return View(videoDTO);
        }

        // GET: VideoDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Time,Quality,Id,Name")] VideoDTO videoDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoDTO);
        }

        // GET: VideoDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VideoDTO == null)
            {
                return NotFound();
            }

            var videoDTO = await _context.VideoDTO.FindAsync(id);
            if (videoDTO == null)
            {
                return NotFound();
            }
            return View(videoDTO);
        }

        // POST: VideoDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Time,Quality,Id,Name")] VideoDTO videoDTO)
        {
            if (videoDTO == null)
            {
                return NotFound();
            }

            if (id != videoDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoDTOExists(videoDTO.Id))
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
            return View(videoDTO);
        }

        // GET: VideoDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VideoDTO == null)
            {
                return NotFound();
            }

            var videoDTO = await _context.VideoDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoDTO == null)
            {
                return NotFound();
            }

            return View(videoDTO);
        }

        // POST: VideoDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VideoDTO == null)
            {
                return Problem("Entity set 'MainProjectUIWebContext.VideoDTO'  is null.");
            }
            var videoDTO = await _context.VideoDTO.FindAsync(id);
            if (videoDTO != null)
            {
                _context.VideoDTO.Remove(videoDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoDTOExists(int id)
        {
          return _context.VideoDTO.Any(e => e.Id == id);
        }
    }
}
