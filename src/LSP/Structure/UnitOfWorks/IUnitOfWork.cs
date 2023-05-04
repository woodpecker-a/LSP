namespace Structure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}