using MainProject.BL.DTO;
using MainProject.BL.Extentions;
using MainProject.BL.Interfaces;
using MainProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.BL.Services
{
    public class VideoService : IVideoService
    {

        private readonly IUnitOfWork _unitOfWork;
        public VideoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public VideoDTO AddVideo(VideoDTO videoMaterial)
        {
            _unitOfWork.VideoRepository.AddVideo((videoMaterial).ToModel());
            _unitOfWork.Save();

            return videoMaterial;
        }

        public bool DeleteVideo(VideoDTO videoMaterial)
        {
            bool result = _unitOfWork.VideoRepository.DeleteVideo((videoMaterial).ToModel());
            _unitOfWork.Save();

            return result;
        }

        public List<VideoDTO> GetAllVideo()
        {
            List<VideoDTO> videos = new List<VideoDTO>();
            foreach (var item in _unitOfWork.VideoRepository.GetAllVideo())
            {
                videos.Add((item).ToDTO());
            }

            return videos;
        }

        public VideoDTO UpdateVideo(int id, VideoDTO videokMaterial)
        {
            _unitOfWork.VideoRepository.UpdateVideo(id, (videokMaterial).ToModel());
            _unitOfWork.Save();

            return videokMaterial;
        }
    }
}
