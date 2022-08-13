namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IVideoService
    {
        public Task<VideoDTO> AddVideo(VideoDTO videoMaterial);

        public Task<VideoDTO> UpdateVideo(int id, VideoDTO videoMaterial);

        public List<VideoDTO> GetAllVideo();

        public Task<bool> DeleteVideo(int id);
    }
}
