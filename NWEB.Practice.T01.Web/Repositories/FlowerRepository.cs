using Microsoft.EntityFrameworkCore;
using NWEB.Practice.T01.Web.Data;
using NWEB.Practice.T01.Web.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly ApplicationDbContext _db;

        public FlowerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Flower entity)
        {
            await _db.Flowers.AddAsync(entity);
            return await Save();
        }

        public async Task<ICollection<Flower>> FindAll()
        {
            var flower = await _db.Flowers.ToListAsync();
            return flower;
        }

        public async Task<bool> Delete(Flower entity)
        {
            _db.Flowers.Remove(entity);
            return await Save();
        }

        public async Task<Flower> FindById(int id)
        {
            var flower = await _db.Flowers
                .FirstOrDefaultAsync(q => q.Id == id);
            return flower;
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.Flowers.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Flower entity)
        {
            _db.Flowers.Update(entity);
            return await Save();
        }
    }
}
