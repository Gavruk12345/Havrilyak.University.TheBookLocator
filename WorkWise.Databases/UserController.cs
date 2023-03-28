using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWise.Database.Service;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext; 

namespace WorkWise.Database
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(string name, string email)
        {
            var user = new Customer { Name = name, Email = email };
            _userService.AddCustomer(user);
            return RedirectToAction("Index", "Home");
        }

    }

}
