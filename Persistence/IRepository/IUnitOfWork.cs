using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
    }
}