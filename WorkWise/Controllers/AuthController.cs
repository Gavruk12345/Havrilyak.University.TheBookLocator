using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkWise.Database;
using WorkWise.Database.Service;
using WorkWise.Database.Interfaces;
using WorkWise.Model.Database.Tables;

namespace WorkWise.Controllers
{
    public class AuthController : Controller
    {
        private readonly StoreDbContext _dbContext;

        public AuthController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var userService = new UserService(_dbContext);
            var isAuthenticated = await userService.EmailAndPasswordMatch(email, password);

            if (isAuthenticated)
            {
                // Перенаправлення до кабінету або іншої сторінки після успішної авторизації
                return RedirectToAction("Index", "Cabinet");
            }
            else
            {
                // Обробка помилки авторизації, наприклад, відображення повідомлення про невірний логін або пароль
                ModelState.AddModelError(string.Empty, "Невірний логін або пароль");
                return View();
            }
        }
    }
}
