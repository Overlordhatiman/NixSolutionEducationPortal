namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;
    using Microsoft.Extensions.DependencyInjection;

    public class MaterialsCRUD
    {
        private ServiceProvider _service;
        private static MaterialValidation _materialValidation;

        public MaterialsCRUD(ServiceProvider service)
        {
            this._service = service;
            _materialValidation = new MaterialValidation();
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
            var collection = _service.GetRequiredService<IMaterialsService>().GetAllMaterial();

            foreach (var item in collection)
            {
                Console.WriteLine(item.Id + "\t" + item.Name);
            }

            Console.ReadKey();
        }


        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            Int32.TryParse(Console.ReadLine(), out id);

            return id;
        }
        public static MaterialsDTO GetMaterials()
        {
            Console.WriteLine("Input ID");
            int id;
            Int32.TryParse(Console.ReadLine(), out id);

            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            MaterialsDTO mat = new MaterialsDTO
            {
                Id = id,
                Name = s,
            };

            return ValidateMaterial(mat);
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

        private void CreateMaterial(MaterialsDTO materialsDTO)
        {
            if (materialsDTO == null)
            {
                return;
            }
            _service.GetRequiredService<IMaterialsService>().AddMaterial(materialsDTO);
        }

        private void UpdateMaterial(MaterialsDTO materialsDTO)
        {
            if (materialsDTO == null)
            {
                return;
            }
            _service.GetRequiredService<IMaterialsService>().UpdateMaterial(materialsDTO.Id, materialsDTO);
        }

        private void DeleteMaterial(int id)
        {
            _service.GetRequiredService<IMaterialsService>().DeleteMaterial(id);
        }
    }
}
