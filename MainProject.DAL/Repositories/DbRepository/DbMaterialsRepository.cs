namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbMaterialsRepository : BaseRepository<Materials>, IMaterialsRepository
    {
        private EducationPortalContext _context;

        public DbMaterialsRepository(EducationPortalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Materials> AddMaterial(Materials material)
        {
            Add(material);

            return material;
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<Materials>> GetAllMaterial()
        {
            return await _context.Materials.Include(m => m.Courses).ToListAsync();
        }

        public async Task<IEnumerable<ArticleMaterial>> GetAllArticle()
        {
            return await _context.Materials.OfType<ArticleMaterial>().Include(m => m.Courses).ToListAsync();
        }

        public async Task<IEnumerable<BookMaterial>> GetAllBook()
        {
            return await _context.Materials.OfType<BookMaterial>().Include(m => m.Courses).ToListAsync();
        }

        public async Task<IEnumerable<VideoMaterial>> GetAllVideo()
        {
            return await _context.Materials.OfType<VideoMaterial>().Include(m => m.Courses).ToListAsync();
        }

        public async Task<Materials> UpdateMaterial(Materials material)
        {
            if (material == null)
            {
                throw new NullReferenceException();
            }

            await Update(material);

            return material;
        }

        public async Task<Materials> GetMaterials(int id)
        {
            return await _context.Materials.Include(m => m.Courses).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
