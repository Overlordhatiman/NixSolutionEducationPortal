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

        public TEntity Add(TEntity obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public bool Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            var obj = _dbSet.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.Find(id);
            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public TEntity Update(TEntity obj)
        {
            _dbSet.Update(obj);
            _context.SaveChanges();

            return obj;
        }
    }
}
