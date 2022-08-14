namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IVideoRepository
    {
        public VideoMaterial AddVideo(VideoMaterial videokMaterial);

        public Task<VideoMaterial> UpdateVideo(VideoMaterial videokMaterial);

        public Task<IEnumerable<VideoMaterial>> GetAllVideo();

        public Task<bool> DeleteVideo(int id);

        public Task<VideoMaterial> GetVideoMaterial(int id);
    }
}
