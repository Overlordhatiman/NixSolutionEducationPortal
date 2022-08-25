namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbVideoRepository : IVideoRepository
    {
        private EducationPortalContext _context;

        public DbVideoRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public VideoMaterial AddVideo(VideoMaterial videoMaterial)
        {
            _context.Videos.Add(videoMaterial);
            _context.SaveChanges();

            return videoMaterial;
        }

        public bool DeleteVideo(int id)
        {
            var entityToDelete = _context.Videos.SingleOrDefault(e => e.Id == id);
            var obj = _context.Videos.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<VideoMaterial> GetAllVideo()
        {
            return _context.Videos.AsNoTracking().ToList();
        }

        public VideoMaterial UpdateVideo(VideoMaterial videoMaterial)
        {
            if (videoMaterial == null)
            {
                throw new NullReferenceException();
            }

            _context.Update(videoMaterial);
            _context.SaveChanges();

            return videoMaterial;
        }

        public VideoMaterial GetVideoMaterial(int id)
        {
            return _context.Videos.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
    }
}
