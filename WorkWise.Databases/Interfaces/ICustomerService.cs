using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Model.Databases;

namespace WorkWise.Database.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void Save();
    }

}


