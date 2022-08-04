namespace MainProject.DAL.Interfaces
{
    using MainProject.src.Models;

    public interface IMaterialsRepository
    {
        public Materials AddMaterial(Materials material);

        public Materials UpdateMaterial(int id, Materials material);

        public List<Materials> GetAllMaterial();

        public bool DeleteMaterial(int id);
    }
}
