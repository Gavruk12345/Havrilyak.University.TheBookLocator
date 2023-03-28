using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Databases;
using WorkWise.Model.Databases;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WorkWise.Database.Service
{
    public class UserService : IUserService
    {
        private readonly StoreDbContext _storeDbContext;

        public UserService(StoreDbContext dbContext)
        {
            _storeDbContext = dbContext;
        }

        public void AddUser(Customer user)
        {
            _storeDbContext.Customers.Add(user);
            _storeDbContext.SaveChanges();
        }
    }
}
