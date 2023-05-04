using Microsoft.EntityFrameworkCore;
using Structure.Entities;

namespace Structure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}