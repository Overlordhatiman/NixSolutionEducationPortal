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
            _unitOfWork.Save();

            return videoMaterial;
        }

        public async Task<bool> DeleteVideo(int id)
        {
            bool result = _unitOfWork.VideoRepository.DeleteVideo(id);
            await _unitOfWork.Save();

            return result;
        }

        public List<VideoDTO> GetAllVideo()
        {
            List<VideoDTO> videos = new List<VideoDTO>();
            foreach (var item in _unitOfWork.VideoRepository.GetAllVideo())
            {
                videos.Add(item.ToDTO());
            }

            return videos;
        }

        public async Task<VideoDTO> UpdateVideo(int id, VideoDTO videokMaterial)
        {
            _unitOfWork.VideoRepository.UpdateVideo(id, videokMaterial.ToModel());
            await _unitOfWork.Save();

            return videokMaterial;
        }
    }
}
