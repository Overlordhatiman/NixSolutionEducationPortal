namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;

    public class MaterialsController
    {
        private MaterialValidation _materialValidation;

        private IMaterialsService _materialsService;

        public MaterialsController(IMaterialsService materialsService)
        {
            _materialsService = materialsService;
            _materialValidation = new MaterialValidation();
        }

        public void SaveMaterials(MaterialsDTO materials)
        {
            if (materials == null)
            {
                return;
            }

            _materialsService.AddMaterial(materials);
        }

        public async Task<MaterialsDTO> GetMaterialById(int id)
        {
            return await _materialsService.GetMaterials(id);
        }

        public void SaveMaterialAfterUpdate(MaterialsDTO materials)
        {
            Update(materials);
        }

        public MaterialsDTO GetMaterialFromConsole()
        {
            Console.WriteLine("Select material 1 - Article, 2 - Book, 3 - Video");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            MaterialsDTO material;
            string name;

            switch (select)
            {
                case 1:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    Console.WriteLine("Input date of article");
                    DateTime dateTime;
                    DateTime.TryParse(Console.ReadLine(), out dateTime);

                    Console.WriteLine("Input URL for resource");
                    string resourse = Console.ReadLine();

                    material = new ArticleDTO
                    {
                        Name = name,
                        Date = dateTime,
                        Resource = resourse,
                    };
                    break;
                case 2:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    Console.WriteLine("Input Author");
                    string author = Console.ReadLine();

                    Console.WriteLine("Input Number of pages");
                    int pages;
                    int.TryParse(Console.ReadLine(), out pages);

                    Console.WriteLine("Input format");
                    string format = Console.ReadLine();

                    Console.WriteLine("Input Date of publication");
                    DateTime date;
                    DateTime.TryParse(Console.ReadLine(), out date);

                    material = new BookDTO
                    {
                        Name = name,
                        Author = author,
                        NumberOfPages = pages,
                        Format = format,
                        Date = date,
                    };
                    break;
                case 3:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    Console.WriteLine("Input time of video");
                    int time;
                    int.TryParse(Console.ReadLine(), out time);

                    Console.WriteLine("Input Quality");
                    string quality = Console.ReadLine();

                    material = new VideoDTO
                    {
                        Name = name,
                        Time = time,
                        Quality = quality,
                    };
                    break;
                default:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    material = new MaterialsDTO
                    {
                        Name = name,
                    };
                    break;
            }

            return Validate(material);
        }

        public void CreateMaterial()
        {
            CreateMaterial(GetMaterialFromConsole());
        }

        public MaterialsDTO GetMaterialFromConsole(MaterialsDTO oldMaterial)
        {
            MaterialsDTO material;
            string name;

            switch (oldMaterial)
            {
                case ArticleDTO:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    Console.WriteLine("Input date of article");
                    DateTime dateTime;
                    DateTime.TryParse(Console.ReadLine(), out dateTime);

                    Console.WriteLine("Input URL for resource");
                    string resourse = Console.ReadLine();

                    material = new ArticleDTO
                    {
                        Name = name,
                        Date = dateTime,
                        Resource = resourse,
                    };
                    break;
                case BookDTO:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    Console.WriteLine("Input Author");
                    string author = Console.ReadLine();

                    Console.WriteLine("Input Number of pages");
                    int pages;
                    int.TryParse(Console.ReadLine(), out pages);

                    Console.WriteLine("Input format");
                    string format = Console.ReadLine();

                    Console.WriteLine("Input Date of publication");
                    DateTime date;
                    DateTime.TryParse(Console.ReadLine(), out date);

                    material = new BookDTO
                    {
                        Name = name,
                        Author = author,
                        NumberOfPages = pages,
                        Format = format,
                        Date = date,
                    };
                    break;
                case VideoDTO:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    Console.WriteLine("Input time of video");
                    int time;
                    int.TryParse(Console.ReadLine(), out time);

                    Console.WriteLine("Input Quality");
                    string quality = Console.ReadLine();

                    material = new VideoDTO
                    {
                        Name = name,
                        Time = time,
                        Quality = quality,
                    };
                    break;
                default:
                    Console.WriteLine("Input Name");
                    name = Console.ReadLine();

                    material = new MaterialsDTO
                    {
                        Name = name,
                    };
                    break;
            }

            return material;
        }

        public void UpdateMaterial()
        {
            OutputMaterials();

            Update();
        }

        public void DeleteMaterial()
        {
            DeleteMaterial(GetId());
        }

        public void OutputMaterials()
        {
            Output();
        }

        private async Task Output()
        {
            Console.WriteLine("Materials");
            var materials = await GetAllMaterials();

            foreach (var material in materials)
            {
                Console.WriteLine(material);
            }

            Console.ReadKey();
        }

        private async Task<List<MaterialsDTO>> GetAllMaterials()
        {
            return await _materialsService.GetAllMaterial();
        }

        private MaterialsDTO Validate(MaterialsDTO material)
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

        private async Task Update()
        {
            int id = GetId();
            Console.WriteLine("Current object");
            MaterialsDTO oldMaterial = await _materialsService.GetMaterials(id);
            Console.WriteLine(oldMaterial);
            MaterialsDTO materials = GetMaterialFromConsole(oldMaterial);
            materials.Id = id;

            _materialsService.UpdateMaterial(materials);
        }

        private async Task Update(MaterialsDTO materials)
        {
            _materialsService.UpdateMaterial(materials);
        }

        private async Task DeleteMaterial(int id)
        {
            _materialsService.DeleteMaterial(id);
        }
    }
}
