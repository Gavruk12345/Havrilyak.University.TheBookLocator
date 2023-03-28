using System.Collections.Generic;
using WorkWise.Database.Interfaces;
using WorkWise.Model.Databases;

namespace WorkWise.Databases.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly StoreDbContext _dbContext;

        public CustomerService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }

}
