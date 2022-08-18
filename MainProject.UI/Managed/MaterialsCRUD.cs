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

            MaterialsDTO maerialt = new MaterialsDTO
            {
                Name = s,
            };

            return Validate(maerialt);
        }

        public void CreateMaterial()
        {
            CreateMaterial(GetMaterials());
        }

        public void UpdateMaterial()
        {
            int id = GetId();
            Console.WriteLine("Current object");
            Console.WriteLine(_materialsService.GetMaterials(id));

            UpdateMaterial(GetMaterials(), id);
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

        private static MaterialsDTO Validate(MaterialsDTO material)
        {
            ValidationResult validationResult = _materialValidation.Validate(material);

            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            Console.ReadKey();

            if (validationResult.IsValid)
            {
                return material;
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

        private void UpdateMaterial(MaterialsDTO materialsDTO, int id)
        {
            if (materialsDTO == null)
            {
                return;
            }

            materialsDTO.Id = id;
            _materialsService.UpdateMaterial(materialsDTO);
        }

        private void DeleteMaterial(int id)
        {
            _materialsService.DeleteMaterial(id);
        }
    }
}
