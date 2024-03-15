using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Data;
using Persistence.IRepository;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _dbContext;

        public UnitOfWork(ProductDbContext dbContext)
        {
             _dbContext = dbContext;
        }

        public async Task<bool> Complete()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}