using Microsoft.EntityFrameworkCore;
using Structure.DbContexts;
using Structure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.UnitOfWorks
{
    internal class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IProductRepository Products { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext db, IProductRepository product) : base((DbContext)db)
        {
            Products = product;
        }
    }
}
