using MainProject.BL.DTO;

namespace MainProject.BL.Interfaces
{
    public interface IVideoService
    {
        public VideoDTO AddVideo(VideoDTO videoMaterial);
        public VideoDTO UpdateVideo(int id, VideoDTO videoMaterial);
        public List<VideoDTO> GetAllVideo();
        public bool DeleteVideo(VideoDTO videoMaterial);
    }
}
