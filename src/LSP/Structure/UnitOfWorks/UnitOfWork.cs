using Microsoft.EntityFrameworkCore;

namespace Structure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _db;

        public UnitOfWork(DbContext db) { _db = db; }

        public virtual void Save() => _db.SaveChanges();
        public virtual void Dispose() => _db.Dispose();
    }
}
