namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class BaseRepository<TEntity> : IGenericInterface<TEntity> where TEntity : class
    {
        private EducationPortalContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(EducationPortalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            var obj = _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();

            return obj != null;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();

            return obj;
        }
    }
}
