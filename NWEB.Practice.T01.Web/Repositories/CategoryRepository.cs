using Microsoft.EntityFrameworkCore;
using NWEB.Practice.T01.Web.Data;
using NWEB.Practice.T01.Web.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Category entity)
        {
            await _db.Categories.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Category entity)
        {
            _db.Categories.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Category>> FindAll()
        {
            var Cate = await _db.Categories
                .Include(q => q.Flowers)
                .ToListAsync();
            return Cate;
        }

        public async Task<Category> FindById(int id)
        {
            var Cate = await _db.Categories
                .FirstOrDefaultAsync(q => q.Id == id);
            return Cate;
        }


        public async Task<bool> isExists(int id)
        {
            var exists = await _db.Categories.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Category entity)
        {
            _db.Categories.Update(entity);
            return await Save();
        }
    }
}
