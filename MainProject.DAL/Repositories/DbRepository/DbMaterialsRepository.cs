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
            _context.SaveChanges();

            return material;
        }

        public bool DeleteMaterial(int id)
        {
            var entityToDelete = _context.Materials.SingleOrDefault(e => e.Id == id);
            var obj = _context.Materials.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<Materials> GetAllMaterial()
        {
            return _context.Materials.ToList();
        }

        public Materials UpdateMaterial(Materials material)
        {
            if (material == null)
            {
                return null;
            }

            _context.Entry(material).State = EntityState.Modified;
            _context.SaveChanges();

            return material;
        }

        public Materials GetMaterials(int id)
        {
            return _context.Materials.SingleOrDefault(x => x.Id == id);
        }
    }
}
