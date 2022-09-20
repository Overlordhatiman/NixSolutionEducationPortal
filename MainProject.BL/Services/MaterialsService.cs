namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class MaterialsService : IMaterialsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaterialsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MaterialsDTO> AddMaterial(MaterialsDTO material)
        {
            await _unitOfWork.MaterialsRepository.AddMaterial(material.ToModel(_unitOfWork));

            return material;
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            var result = await _unitOfWork.MaterialsRepository.DeleteMaterial(id);

            return result != null;
        }

        public async Task<IEnumerable<MaterialsDTO>> GetAllMaterial()
        {
            return (await _unitOfWork.MaterialsRepository.GetAllMaterial()).Select(x => x.ToDTO());
        }

        public async Task<IEnumerable<ArticleDTO>> GetAllArticle()
        {
            return (await _unitOfWork.MaterialsRepository.GetAllArticle()).Select(x => x.ToDTO());
        }

        public async Task<IEnumerable<VideoDTO>> GetAllVideo()
        {
            return (await _unitOfWork.MaterialsRepository.GetAllVideo()).Select(x => x.ToDTO());
        }

        public async Task<IEnumerable<BookDTO>> GetAllBook()
        {
            return (await _unitOfWork.MaterialsRepository.GetAllBook()).Select(x => x.ToDTO());
        }

        public async Task<MaterialsDTO> UpdateMaterial(MaterialsDTO material)
        {
            await _unitOfWork.MaterialsRepository.UpdateMaterial(material.ToModel(_unitOfWork));

            return material;
        }

        public async Task<MaterialsDTO> GetMaterials(int id)
        {
            return MaterialMapping.ToDTO(await _unitOfWork.MaterialsRepository.GetMaterials(id));
        }
    }
}
