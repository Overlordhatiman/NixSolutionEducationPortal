namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IVideoService
    {
        public Task<VideoDTO> AddVideo(VideoDTO videoMaterial);

        public Task<VideoDTO> UpdateVideo(VideoDTO videoMaterial);

        public Task<List<VideoDTO>> GetAllVideo();

        public Task<bool> DeleteVideo(int id);

        public Task<VideoDTO> GetVideoMaterial(int id);
    }
}
