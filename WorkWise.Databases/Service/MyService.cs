using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Database.Interfaces;
using WorkWise.Databases;
using WorkWise.Model.Databases;
using Microsoft.EntityFrameworkCore;


namespace WorkWise.Database.Service
{
    public class MyService<T> : IDbEntityService<T> where T : DbItem
    {

        private readonly StoreDbContext _dbContext;
        private bool _disposed;

        public MyService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Create(T entity)
        {
            var entityFromOb = await _dbContext.Set<T>().AddAsync(entity);
            await SaveChanges();

            return entityFromOb.Entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await SaveChanges();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Update(T entity)
        {
            var entityFromOb = _dbContext.Set<T>().Update(entity);
            await SaveChanges();

            return entityFromOb.Entity;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _dbContext.Dispose();
            _disposed = true;
        }
    }
}
