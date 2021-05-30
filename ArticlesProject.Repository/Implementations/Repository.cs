using ArticlesProject.DatabaseEntities;
using ArticlesProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticlesProject.Repository.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _db;
        public Repository(DbContext db)
        {
            _db = db;
        }
        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void DeleteById(object Id)
        {
            var obj = _db.Set<TEntity>().Find(Id);
            if (obj != null)
                _db.Set<TEntity>().Remove(obj);
        }

        public TEntity Find(object Id)
        {
            var obj = _db.Set<TEntity>().Find(Id);
            _db.Entry(obj).State = EntityState.Detached;
            return obj;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }
    }
}
