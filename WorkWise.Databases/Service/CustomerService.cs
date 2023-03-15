using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Database.Interfaces;
using WorkWise.Databases;
using WorkWise.Model.Databases;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WorkWise.Database.Service
{
    public class CustomerService : IDbEntityService<Customer>
    {
        private readonly StoreDbContext _dbContext;
    private bool _disposed;

    public CustomerService(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> NameExists(string Name)
    {
        return await _dbContext.Set<Customer>().AnyAsync(x => x.Name == Name);
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Customer> Create(Customer entity)
    {
        var entityFromOb = await _dbContext.Set<Customer>().AddAsync(entity);
        await SaveChanges();

        return entityFromOb.Entity;
    }

    public async Task Delete(Customer entity)
    {
        _dbContext.Set<Customer>().Remove(entity);
        await SaveChanges();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Customer> Update(Customer entity)
    {
        var entityFromOb = _dbContext.Set<Customer>().Update(entity);
        await SaveChanges();

        return entityFromOb.Entity;
    }

    public IQueryable<Customer> GetAll()
    {
        return _dbContext.Set<Customer>();
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
