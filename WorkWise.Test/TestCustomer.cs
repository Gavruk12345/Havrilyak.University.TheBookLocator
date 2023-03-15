using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Database.Interfaces;
using WorkWise.Databases;
using WorkWise.Model.Databases;
using Microsoft.EntityFrameworkCore;
using WorkWise.Database.Service;
using Microsoft.Extensions.Options;
using WorkWise.Model.Configuration;

namespace WorkWise.Test
{
    
    public class TestCustomer : TestBase
    {
        CustomerService _customerService;
        IOptions<AppConfig> _configuration;
        StoreDbContext _dbContext;

        public TestCustomer()
        {
            _dbContext = ResolveService<StoreDbContext>();
            _customerService = ResolveService<CustomerService>();
            _configuration = ResolveService<IOptions<AppConfig>>();
        }

        
        public async Task Create()
        {
            var customers = await _customerService.Create(new Customer()
            {
                Name = "Jon",
                Email = "Mister@gmail.com"
            });
        }

        
        public void GetAllCustomer()
        {
            var customersTest = _customerService.GetAll();
        }
    }
}
