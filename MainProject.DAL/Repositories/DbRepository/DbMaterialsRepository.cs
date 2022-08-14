namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbMaterialsRepository : IMaterialsRepository
    {
        private EducationPortalContext _context;

        public DbMaterialsRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public Materials AddMaterial(Materials material)
        {
            _context.Materials.Add(material);

            return material;
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            var entityToDelete = await _context.Materials.SingleOrDefaultAsync(e => e.Id == id);
            var obj = _context.Materials.Remove(entityToDelete);

            return obj != null;
        }

        public async Task<IEnumerable<Materials>> GetAllMaterial()
        {
            var materials = await _context.Materials.ToListAsync();

            return materials;
        }

        public async Task<Materials> UpdateMaterial(Materials material)
        {
            if (material == null)
            {
                return null;
            }

            var materialObj = await _context.Materials.FirstOrDefaultAsync(x => x.Id == material.Id);

            if (materialObj != null)
            {
                materialObj.Name = material.Name;
            }

            _context.Entry(materialObj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return material;
        }

        public Task<Materials> GetMaterials(int id)
        {
            return _context.Materials.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
