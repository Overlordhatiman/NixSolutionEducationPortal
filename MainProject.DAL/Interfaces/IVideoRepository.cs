using MainProject.src.Models;

namespace MainProject.DAL.Interfaces
{
    public interface IVideoRepository
    {
        public VideoMaterial AddVideo(VideoMaterial videokMaterial);
        public VideoMaterial UpdateVideo(int id, VideoMaterial videokMaterial);
        public List<VideoMaterial> GetAllVideo();
        public bool DeleteVideo(VideoMaterial videokMaterial);
    }
}
