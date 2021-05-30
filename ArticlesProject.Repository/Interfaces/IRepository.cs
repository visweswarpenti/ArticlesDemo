using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesProject.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Find(object Id);
        void DeleteById(object Id);
    }
}
