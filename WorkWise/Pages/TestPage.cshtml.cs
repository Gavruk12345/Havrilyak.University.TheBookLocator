using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWise.Databases.Models;

namespace WorkWise.Pages
{
    public class TestPageModel : PageModel
    {
            private readonly StoreDbContext _context;

            public TestPageModel(StoreDbContext context)
            {
                _context = context;
            }

            public void OnGet()
            {
            }

            public async Task<IActionResult> OnPostCreateUserAsync(string firstName, string lastName, string email, string phone, string password)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Phone = phone,
                    Password = password
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Index");
            }
        }

    }

