using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkWise.Databases.Model;

namespace WorkWise.Controllers
{
    public class UserController : Controller
    {
        private StoreDbContext db = new StoreDbContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }

}
