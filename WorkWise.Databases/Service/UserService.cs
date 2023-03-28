/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Databases;
using WorkWise.Model.Databases;
using WorkWise.Database.Interfaces;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WorkWise.Database.Service
{
    public class UserService : ICustomerRepository
    {
        private readonly ICustomerRepository _customerRepository;

        public UserService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
            _customerRepository.Save();
        }
    }
            
    

}*/


