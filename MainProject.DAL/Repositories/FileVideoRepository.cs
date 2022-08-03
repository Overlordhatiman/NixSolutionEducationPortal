using MainProject.DAL.Interfaces;
using MainProject.src.Models;
using Newtonsoft.Json;

namespace MainProject.DAL.Repositories
{
    public class FileVideoRepository : IVideoRepository
    {
        private List<VideoMaterial> _videos;

        public FileVideoRepository()
        {
            string str = File.ReadAllText(DALConstant.VideoFilePath);

            _videos = JsonConvert.DeserializeObject<List<VideoMaterial>>(str);
        }

        public VideoMaterial AddVideo(VideoMaterial videokMaterial)
        {
            _videos.Add(videokMaterial);

            return videokMaterial;
        }

        public bool DeleteVideo(VideoMaterial videokMaterial)
        {
            return _videos.Remove(videokMaterial);
        }

        public List<VideoMaterial> GetAllVideo()
        {
            return _videos;
        }

        public VideoMaterial UpdateVideo(int id, VideoMaterial videokMaterial)
        {
            int index = _videos.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return new VideoMaterial();
            }

            _videos[index] = videokMaterial;

            return videokMaterial;
        }

        public void Save()
        {
            var str = JsonConvert.SerializeObject(_videos, Formatting.Indented);

            File.WriteAllText(DALConstant.VideoFilePath, str);
        }
    }
}
