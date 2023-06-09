using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWise.Database.Interfaces;
using WorkWise.Model.Database;
using WorkWise.Database;
using System.Globalization;
using WorkWise.Database.Service;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using WorkWise.Model.Database.Tables;
using WorkWise.Model.Frontend;

namespace WorkWise.Pages
{
    public class UserService : PageModel
    {
        [BindProperty]
        public CreateUser Users { get; set; }

        private readonly Database.Service.UserService _userService;

        public UserService(Database.Service.UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }

            // Check if username already exists
            if (await _userService.UserNameExists(Users.Nickname))
            {
                ModelState.AddModelError("Users.Nickname", "Username already exists.");
                OnGet();
                return Page();
            }

            // Check if email already exists
            else if (await _userService.EmailExists(Users.Email))
            {
                ModelState.AddModelError("Users.EmailAddress", "Current email already in use.");
                OnGet();
                return Page();
            }

            await _userService.Create(new Users()
            {
                Nickname = Users.Nickname,
                Email = Users.Email,
                Password = Users.Password,
                RegDate = DateTime.Now,
            });

            return new RedirectToPageResult("/Index");
        }

        internal Task EmailAndPasswordMatch(string? email, string? password)
        {
            throw new NotImplementedException();
        }
    }
}