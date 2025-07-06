using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace GoalsTracker.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string User { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            return RedirectToPage("/Index");
        }   
    }
}
