using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkWise.Databases.Models;

namespace WorkWise.Controllers
{
    public class UserController : Controller
    {
        private readonly StoreDbContext _context;

        public UserController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }

}
