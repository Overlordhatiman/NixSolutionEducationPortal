namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IVideoRepository
    {
        public VideoMaterial AddVideo(VideoMaterial videokMaterial);

        public VideoMaterial UpdateVideo(int id, VideoMaterial videokMaterial);

        public IEnumerable<VideoMaterial> GetAllVideo();

        public bool DeleteVideo(int id);
    }
}
