namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class DbVideoRepository : IVideoRepository
    {
        private EducationPortalContext _context;

        public DbVideoRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public VideoMaterial AddVideo(VideoMaterial videokMaterial)
        {
            _context.Videos.Add(videokMaterial);

            return videokMaterial;
        }

        public bool DeleteVideo(int id)
        {
            var obj = _context.Videos.Remove(_context.Videos.SingleOrDefault(e => e.Id == id));

            return obj != null;
        }

        public IEnumerable<VideoMaterial> GetAllVideo()
        {
            return _context.Videos;
        }

        public VideoMaterial UpdateVideo(int id, VideoMaterial videokMaterial)
        {
            var video = _context.Videos.SingleOrDefault(x => x.Id == id);

            video = videokMaterial;

            return videokMaterial;
        }
    }
}
