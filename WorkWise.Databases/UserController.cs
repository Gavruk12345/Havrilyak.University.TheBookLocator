using Microsoft.AspNetCore.Mvc;
using WorkWise.Database.Interfaces;
using WorkWise.Database.Interfaces;
using WorkWise.Model.Databases;

namespace WorkWise.Controllers
{
    public class UserController : Controller
    {
        private readonly ICustomerService _customerService;

        public UserController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Login(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("", "Name and email are required.");
                return View();
            }

            var customer = new Customer
            {
                Name = name,
                Email = email
            };

            _customerService.AddCustomer(customer);

            return RedirectToAction("Index", "Home");
        }
    }
}



