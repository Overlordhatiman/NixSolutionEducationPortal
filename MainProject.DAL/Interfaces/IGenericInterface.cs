using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface IGenericInterface<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity obj);

        public TEntity Update(TEntity obj);

        public IEnumerable<TEntity> GetAll();

        public bool Delete(int id);

        public TEntity GetById(int id);
    }
}
