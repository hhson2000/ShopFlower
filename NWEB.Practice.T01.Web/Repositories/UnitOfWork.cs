using NWEB.Practice.T01.Web.Data;
using NWEB.Practice.T01.Web.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Flower> _flower;
        private IGenericRepository<Category> _cate;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Category> Categories
           => _cate ??= new GenericRepository<Category>(_context);

        public IGenericRepository<Flower> Flowers
          => _flower ??= new GenericRepository<Flower>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

