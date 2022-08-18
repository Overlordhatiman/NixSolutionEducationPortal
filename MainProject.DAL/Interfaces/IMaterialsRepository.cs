namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IMaterialsRepository
    {
        public Materials AddMaterial(Materials material);

        public Materials UpdateMaterial(Materials material);

        public IEnumerable<Materials> GetAllMaterial();

        public bool DeleteMaterial(int id);

        public Materials GetMaterials(int id);
    }
}
