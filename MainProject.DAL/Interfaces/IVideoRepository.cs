namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IVideoRepository
    {
        public VideoMaterial AddVideo(VideoMaterial videoMaterial);

        public VideoMaterial UpdateVideo(VideoMaterial videoMaterial);

        public IEnumerable<VideoMaterial> GetAllVideo();

        public bool DeleteVideo(int id);

        public VideoMaterial GetVideoMaterial(int id);
    }
}
