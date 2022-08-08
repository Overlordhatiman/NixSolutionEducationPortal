namespace MainProject.DAL.Repositories
{
    using MainProject.DAL.Interfaces;
    using MainProject.src.Models;
    using Newtonsoft.Json;

    public class FileMaterialsRepository : IMaterialsRepository
    {
        private List<Materials>? _materials;

        public FileMaterialsRepository()
        {
            string str = File.ReadAllText(DALConstant.MaterialsFilePath);

            _materials = JsonConvert.DeserializeObject<List<Materials>>(str);
        }

        public Materials AddMaterial(Materials material)
        {
            _materials.Add(material);

            return material;
        }

        public bool DeleteMaterial(int id)
        {
            return _materials.Remove(_materials.Find(x=>x.Id==id));
        }

        public List<Materials> GetAllMaterial()
        {
            return _materials;
        }

        public Materials UpdateMaterial(int id, Materials material)
        {
            int index = _materials.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return new VideoMaterial();
            }

            _materials[index] = material;

            return material;
        }

        public void Save()
        {
            var str = JsonConvert.SerializeObject(_materials, Formatting.Indented);

            File.WriteAllText(DALConstant.MaterialsFilePath, str);
        }
    }
}
