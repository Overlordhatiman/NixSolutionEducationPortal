using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface IGenericInterface<TEntity> where TEntity : class
    {
        public Task<TEntity> Add(TEntity obj);

        public Task<TEntity> Update(TEntity obj);

        public Task<IEnumerable<TEntity>> GetAll();

        public Task<bool> Delete(int id);

        public Task<TEntity> GetById(int id);
    }
}
