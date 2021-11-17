using NWEB.Practice.T01.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.IRepositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Flower> Flowers { get; }
        IGenericRepository<Category> Categories { get; }
        Task Save();
    }
}
