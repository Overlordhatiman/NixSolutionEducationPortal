namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class VideoService : IVideoService
    {

        private readonly IUnitOfWork unitOfWork;
        public VideoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public VideoDTO AddVideo(VideoDTO videoMaterial)
        {
            this.unitOfWork.VideoRepository.AddVideo(videoMaterial.ToModel());
            this.unitOfWork.Save();

            return videoMaterial;
        }

        public bool DeleteVideo(int id)
        {
            bool result = this.unitOfWork.VideoRepository.DeleteVideo(id);
            this.unitOfWork.Save();

            return result;
        }

        public List<VideoDTO> GetAllVideo()
        {
            List<VideoDTO> videos = new List<VideoDTO>();
            foreach (var item in this.unitOfWork.VideoRepository.GetAllVideo())
            {
                videos.Add(item.ToDTO());
            }

            return videos;
        }

        public VideoDTO UpdateVideo(int id, VideoDTO videokMaterial)
        {
            this.unitOfWork.VideoRepository.UpdateVideo(id, videokMaterial.ToModel());
            this.unitOfWork.Save();

            return videokMaterial;
        }
    }
}
