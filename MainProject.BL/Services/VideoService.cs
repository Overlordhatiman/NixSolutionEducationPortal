namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<VideoDTO> AddVideo(VideoDTO videoMaterial)
        {
            _unitOfWork.VideoRepository.AddVideo(videoMaterial.ToModel());

            return videoMaterial;
        }

        public async Task<bool> DeleteVideo(int id)
        {
            var result = await _unitOfWork.VideoRepository.DeleteVideo(id);

            return result != null;
        }

        public async Task<List<VideoDTO>> GetAllVideo()
        {
            List<VideoDTO> videos = new List<VideoDTO>();
            foreach (var item in await _unitOfWork.VideoRepository.GetAllVideo())
            {
                videos.Add(item.ToDTO());
            }

            return videos;
        }

        public async Task<VideoDTO> UpdateVideo(VideoDTO videokMaterial)
        {
            await _unitOfWork.VideoRepository.UpdateVideo(videokMaterial.ToModel());

            return videokMaterial;
        }

        public async Task<VideoDTO> GetVideoMaterial(int id)
        {
            var videoMaterial = await _unitOfWork.VideoRepository.GetVideoMaterial(id);

            return videoMaterial.ToDTO();
        }
    }
}
