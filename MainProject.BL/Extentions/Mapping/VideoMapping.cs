namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class VideoMapping
    {
        public static VideoDTO ToDTO(this VideoMaterial videoMaterial)
        {
            if (videoMaterial == null)
            {
                return new VideoDTO();
            }

            return new VideoDTO
            {
                Id = videoMaterial.Id,
                Name = videoMaterial.Name,
                Quality = videoMaterial.Quality,
                Time = videoMaterial.Time,
            };
        }

        public static VideoMaterial ToModel(this VideoDTO video)
        {
            if (video == null)
            {
                return new VideoMaterial();
            }

            return new VideoMaterial
            {
                Id = video.Id,
                Name = video.Name,
                Quality = video.Quality,
                Time = video.Time,
            };
        }
    }
}
