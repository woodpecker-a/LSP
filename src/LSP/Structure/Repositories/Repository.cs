using Microsoft.EntityFrameworkCore;
using Structure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected DbContext _db;
        protected DbSet<TEntity> _dbSet;

        public Repository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Edit(TEntity entityToUpdate)
        {
            if (_db.Entry(entityToUpdate).State == EntityState.Detached)
                _db.Attach(entityToUpdate);
            _db.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public void Remove(TEntity entityToDelete)
        {
            if (_db.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }
    }
}
