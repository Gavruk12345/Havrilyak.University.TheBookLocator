using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Database;
using WorkWise.Model.Databases;

namespace WorkWise.Database.Interfaces
{
    public interface IDbEntityService<T> where T : DbItem
    {
        Task<T> GetById(int id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);

        IQueryable<T> GetAll();
    }
}
