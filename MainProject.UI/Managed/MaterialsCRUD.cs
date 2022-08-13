namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;

    public class MaterialsCRUD
    {
        private static MaterialValidation _materialValidation;

        private IMaterialsService _materialsService;

        public MaterialsCRUD(IMaterialsService materialsService)
        {
            _materialsService = materialsService;
            _materialValidation = new MaterialValidation();
        }

        public static MaterialsDTO GetMaterials()
        {
            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            MaterialsDTO mat = new MaterialsDTO
            {
                Name = s,
            };

            return ValidateMaterial(mat);
        }

        public void CreateMaterial()
        {
            CreateMaterial(GetMaterials());
        }

        public void UpdateMaterial()
        {
            UpdateMaterial(GetMaterials());
        }

        public void DeleteMaterial()
        {
            DeleteMaterial(GetId());
        }

        public void OutputMaterials()
        {
            Console.WriteLine("Materials");
            var materials = _materialsService.GetAllMaterial();

            foreach (var material in materials)
            {
                Console.WriteLine(material);
            }

            Console.ReadKey();
        }

        private static MaterialsDTO ValidateMaterial(MaterialsDTO mat)
        {
            ValidationResult validationResult = _materialValidation.Validate(mat);

            foreach (var item in validationResult.Errors)
            {
                Console.WriteLine(item.ErrorMessage);
            }

            Console.ReadKey();

            if (validationResult.IsValid)
            {
                return mat;
            }

            return null;
        }

        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            return id;
        }

        private void CreateMaterial(MaterialsDTO materialsDTO)
        {
            if (materialsDTO == null)
            {
                return;
            }

            _materialsService.AddMaterial(materialsDTO);
        }

        private void UpdateMaterial(MaterialsDTO materialsDTO)
        {
            if (materialsDTO == null)
            {
                return;
            }

            _materialsService.UpdateMaterial(materialsDTO.Id, materialsDTO);
        }

        private void DeleteMaterial(int id)
        {
            _materialsService.DeleteMaterial(id);
        }
    }
}
