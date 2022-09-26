namespace MainProject.UI.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class VideoDTOesController : Controller
    {
        private readonly IMaterialsService materialsService;

        public VideoDTOesController(IMaterialsService service)
        {
            materialsService = service;
        }

        // GET: VideoDTOes
        public async Task<IActionResult> Index()
        {
            return View((await materialsService.GetAllVideo()));
        }

        // GET: VideoDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoDTO = await materialsService.GetMaterials((int)id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Time,Quality,Id,Name")] VideoDTO videoDTO)
        {
            if (ModelState.IsValid)
            {
                await materialsService.AddMaterial(videoDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(videoDTO);
        }

        // GET: VideoDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoDTO = await materialsService.GetMaterials((int)id);
            if (videoDTO == null)
            {
                return NotFound();
            }
            return View(videoDTO);
        }

        // POST: VideoDTOes/Edit/5
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
                    await materialsService.UpdateMaterial(videoDTO);
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
            if (id == null)
            {
                return NotFound();
            }

            var videoDTO = await materialsService.GetMaterials((int)id);
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
            await materialsService.DeleteMaterial(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VideoDTOExists(int id)
        {
          return materialsService.GetMaterials(id) == null;
        }
    }
}
