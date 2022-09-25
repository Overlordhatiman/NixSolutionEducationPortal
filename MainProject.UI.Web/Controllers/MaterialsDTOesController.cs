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
    public class MaterialsDTOesController : Controller
    {
        private readonly IMaterialsService materialsService;

        public MaterialsDTOesController(IMaterialsService service)
        {
            materialsService = service;
        }

        // GET: MaterialsDTOes
        public async Task<IActionResult> Index()
        {
              return View(await materialsService.GetAllMaterial());
        }

        // GET: MaterialsDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialsDTO = await materialsService.GetMaterials((int)id);
            if (materialsDTO == null)
            {
                return NotFound();
            }

            return View(materialsDTO);
        }

        // GET: MaterialsDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: MaterialsDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialsDTO = await materialsService.GetMaterials((int)id);
            if (materialsDTO == null)
            {
                return NotFound();
            }
            return View(materialsDTO);
        }

        // POST: MaterialsDTOes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MaterialsDTO materialsDTO)
        {
            if (materialsDTO == null)
            {
                return NotFound();
            }

            if (id != materialsDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    materialsService.UpdateMaterial(materialsDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialsDTOExists(materialsDTO.Id))
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
            return View(materialsDTO);
        }

        // GET: MaterialsDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialsDTO = await materialsService.GetMaterials((int)id);
            if (materialsDTO == null)
            {
                return NotFound();
            }

            return View(materialsDTO);
        }

        // POST: MaterialsDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            materialsService.DeleteMaterial(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MaterialsDTOExists(int id)
        {
          return materialsService.GetMaterials(id) == null;
        }
    }
}
