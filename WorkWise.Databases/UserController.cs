using Microsoft.AspNetCore.Mvc;
using WorkWise.Database.Interfaces;
using WorkWise.Model.Databases;
using WorkWise.Pages;

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
        public IActionResult SignIn([FromForm] string name, [FromForm] string email)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("", "Name and email are required.");
                return View();
            }

            var customer = new Customer
            {
                Name = Request.Form["name"],
                Email = Request.Form["email"]
            };

            _customerService.AddCustomer(customer);
            _customerService.Save();


            return RedirectToAction("Index", "Home");
        }
    }
}



