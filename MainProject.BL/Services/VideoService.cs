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

        public VideoDTO AddVideo(VideoDTO videoMaterial)
        {
            _unitOfWork.VideoRepository.AddVideo(videoMaterial.ToModel());

            return videoMaterial;
        }

        public bool DeleteVideo(int id)
        {
            var result = _unitOfWork.VideoRepository.DeleteVideo(id);

            return result != null;
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

        public VideoDTO UpdateVideo(VideoDTO videokMaterial)
        {
            _unitOfWork.VideoRepository.UpdateVideo(videokMaterial.ToModel());

            return videokMaterial;
        }

        public VideoDTO GetVideoMaterial(int id)
        {
           return _unitOfWork.VideoRepository.GetVideoMaterial(id).ToDTO();
        }
    }
}
