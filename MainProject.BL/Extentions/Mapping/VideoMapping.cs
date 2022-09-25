namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Interfaces;
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

        public static VideoMaterial ToModel(this VideoDTO video, IUnitOfWork unitOfWork)
        {
            if (video == null)
            {
                return new VideoMaterial();
            }

            Materials materials;
            if (video.Id != 0 && unitOfWork != null)
            {
                materials = unitOfWork.MaterialsRepository.GetMaterials(video.Id).Result;
                VideoMaterial videoMaterial = (VideoMaterial)materials;
                videoMaterial.Id = video.Id;
                videoMaterial.Name = video.Name;
                videoMaterial.Quality = video.Quality;
                videoMaterial.Time = video.Time;
                materials = videoMaterial;
            }
            else
            {
                materials = new VideoMaterial
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Time = video.Time,
                };
            }

            return (VideoMaterial)materials;
        }
    }
}
