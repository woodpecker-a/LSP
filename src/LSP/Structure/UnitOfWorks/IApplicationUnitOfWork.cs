using Structure.Repositories;

namespace Structure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}