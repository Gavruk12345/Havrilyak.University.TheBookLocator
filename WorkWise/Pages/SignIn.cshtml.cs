using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkWise.Pages
{
    public class SignInModel : PageModel
    {

        [HttpPost]
        public IActionResult Create(SignInModel model)
        {
            var client = new Customer
            {
                Name = model.Name,
                Email = model.Email,
            };

            _customerService.Clients.Add(client);
            _customerService.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
