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

        public VideoMaterial AddVideo(VideoMaterial videokMaterial)
        {
            _context.Videos.Add(videokMaterial);

            return videokMaterial;
        }

        public async Task<bool> DeleteVideo(int id)
        {
            var entityToDelete = await _context.Videos.SingleOrDefaultAsync(e => e.Id == id);
            var obj = _context.Videos.Remove(entityToDelete);

            return obj != null;
        }

        public async Task<IEnumerable<VideoMaterial>> GetAllVideo()
        {
            var videos = await _context.Videos.ToListAsync();

            return videos;
        }

        public async Task<VideoMaterial> UpdateVideo(VideoMaterial videokMaterial)
        {
            if (videokMaterial == null)
            {
                return null;
            }

            var video = await _context.Videos.FirstOrDefaultAsync(x => x.Id == videokMaterial.Id);
            if (video != null)
            {
                video.Name = videokMaterial.Name;
                video.Time = videokMaterial.Time;
                video.Quality = videokMaterial.Quality;
            }

            _context.Entry(video).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return videokMaterial;
        }

        public Task<VideoMaterial> GetVideoMaterial(int id)
        {
            return _context.Videos.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
