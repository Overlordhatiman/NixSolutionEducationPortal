namespace MainProject.DAL.Interfaces
{
    using MainProject.src.Models;

    public interface IVideoRepository
    {
        public VideoMaterial AddVideo(VideoMaterial videokMaterial);

        public VideoMaterial UpdateVideo(int id, VideoMaterial videokMaterial);

        public List<VideoMaterial> GetAllVideo();

        public bool DeleteVideo(int id);
    }
}
