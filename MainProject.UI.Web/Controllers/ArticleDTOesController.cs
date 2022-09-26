using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainProject.BL.DTO;
using MainProject.BL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MainProject.UI.Web.Controllers
{
    [Authorize]
    public class ArticleDTOesController : Controller
    {
        private readonly IMaterialsService materialsService;

        public ArticleDTOesController(IMaterialsService service)
        {
            materialsService = service;
        }

        // GET: ArticleDTOes
        public async Task<IActionResult> Index()
        {
              return View((await materialsService.GetAllArticle()));
        }

        // GET: ArticleDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleDTO = await materialsService.GetMaterials((int)id);
            if (articleDTO == null)
            {
                return NotFound();
            }

            return View(articleDTO);
        }

        // GET: ArticleDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleDTOes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Resource,Id,Name")] ArticleDTO articleDTO)
        {
            if (ModelState.IsValid)
            {
                await materialsService.AddMaterial(articleDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(articleDTO);
        }

        // GET: ArticleDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleDTO = await materialsService.GetMaterials((int)id);
            if (articleDTO == null)
            {
                return NotFound();
            }
            return View(articleDTO);
        }

        // POST: ArticleDTOes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Resource,Id,Name")] ArticleDTO articleDTO)
        {
            if (articleDTO == null)
            {
                return NotFound();
            }

            if (id != articleDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await materialsService.UpdateMaterial(articleDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleDTOExists(articleDTO.Id))
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
            return View(articleDTO);
        }

        // GET: ArticleDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleDTO = await materialsService.GetMaterials((int)id);
            if (articleDTO == null)
            {
                return NotFound();
            }

            return View(articleDTO);
        }

        // POST: ArticleDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await materialsService.DeleteMaterial(id);
            
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleDTOExists(int id)
        {
          return materialsService.GetMaterials(id) == null;
        }
    }
}
