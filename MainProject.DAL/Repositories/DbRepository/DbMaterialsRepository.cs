namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

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

        public bool DeleteMaterial(int id)
        {
            var obj = _context.Materials.Remove(_context.Materials.SingleOrDefault(e => e.Id == id));

            return obj != null;
        }

        public IEnumerable<Materials> GetAllMaterial()
        {
            return _context.Materials;
        }

        public Materials UpdateMaterial(int id, Materials material)
        {
            var materialObj = _context.Materials.SingleOrDefault(x => x.Id == id);

            materialObj = material;

            return material;
        }
    }
}
