namespace MainProject.UI.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class BookDTOesController : Controller
    {
        private readonly IMaterialsService materialsService;

        public BookDTOesController(IMaterialsService service)
        {
            materialsService = service;
        }

        // GET: BookDTOes
        public async Task<IActionResult> Index()
        {
              return View((await materialsService.GetAllBook()));
        }

        // GET: BookDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDTO = await materialsService.GetMaterials((int)id);
            if (bookDTO == null)
            {
                return NotFound();
            }

            return View(bookDTO);
        }

        // GET: BookDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookDTOes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Author,NumberOfPages,Format,Date,Id,Name")] BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                await materialsService.AddMaterial(bookDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(bookDTO);
        }

        // GET: BookDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDTO = await materialsService.GetMaterials((int)id);
            if (bookDTO == null)
            {
                return NotFound();
            }
            return View(bookDTO);
        }

        // POST: BookDTOes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Author,NumberOfPages,Format,Date,Id,Name")] BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return NotFound();
            }

            if (id != bookDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await materialsService.UpdateMaterial(bookDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookDTOExists(bookDTO.Id))
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
            return View(bookDTO);
        }

        // GET: BookDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDTO = await materialsService.GetMaterials((int)id);
            if (bookDTO == null)
            {
                return NotFound();
            }

            return View(bookDTO);
        }

        // POST: BookDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            materialsService.DeleteMaterial(id);

            return RedirectToAction(nameof(Index));
        }

        private bool BookDTOExists(int id)
        {
          return materialsService.GetMaterials(id) == null;
        }
    }
}
