using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface ISqlRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Remove(int id);
        void Update(TEntity entity);
        bool SaveChanges();
    }
}
