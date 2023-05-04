using Microsoft.EntityFrameworkCore;
using Structure.DbContexts;
using Structure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }
    }
}
