using Structure.Entities;

namespace Structure.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);
        TEntity GetById(TKey id);
        IList<TEntity> GetAll();
        void Edit(TEntity entityToUpdate);
        void Remove(TKey id);
        void Remove(TEntity entityToDelete);
    }
}