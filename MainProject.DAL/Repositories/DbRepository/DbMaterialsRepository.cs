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

        public async Task<Materials> AddMaterial(Materials material)
        {
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();

            return material;
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            var entityToDelete = _context.Materials.SingleOrDefault(e => e.Id == id);
            var obj = _context.Materials.Remove(entityToDelete);
            await _context.SaveChangesAsync();

            return obj != null;
        }

        public async Task<IEnumerable<Materials>> GetAllMaterial()
        {
            return await _context.Materials.Include(m => m.Courses).AsNoTracking().ToListAsync();
        }

        public async Task<Materials> UpdateMaterial(Materials material)
        {
            if (material == null)
            {
                throw new NullReferenceException();
            }

            _context.Entry(material).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return material;
        }

        public async Task<Materials> GetMaterials(int id)
        {
            return await _context.Materials.Include(m => m.Courses).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
