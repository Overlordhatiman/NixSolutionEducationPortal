namespace MainProject.DAL.Repositories.FileRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Newtonsoft.Json;

    public class FileVideoRepository : IVideoRepository
    {
        private List<VideoMaterial>? _videos;

        public FileVideoRepository()
        {
            string str = File.ReadAllText(DALConstant.VideoFilePath);

            _videos = JsonConvert.DeserializeObject<List<VideoMaterial>>(str);
        }

        public VideoMaterial AddVideo(VideoMaterial videokMaterial)
        {
            _videos?.Add(videokMaterial);

            return videokMaterial;
        }

        public bool DeleteVideo(int id)
        {
            return _videos.Remove(_videos.Find(x => x.Id == id));
        }

        public IEnumerable<VideoMaterial> GetAllVideo()
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

        public async Task Save()
        {
            var str = JsonConvert.SerializeObject(_videos, Formatting.Indented);

            await File.WriteAllTextAsync(DALConstant.VideoFilePath, str);
        }
    }
}
