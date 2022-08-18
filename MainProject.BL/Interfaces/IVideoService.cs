namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IVideoService
    {
        public VideoDTO AddVideo(VideoDTO videoMaterial);

        public VideoDTO UpdateVideo(VideoDTO videoMaterial);

        public List<VideoDTO> GetAllVideo();

        public bool DeleteVideo(int id);

        public VideoDTO GetVideoMaterial(int id);
    }
}
