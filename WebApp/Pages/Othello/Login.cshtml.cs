using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Security.Claims;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Identity;
using WebApp.Models;
using Microsoft.IdentityModel.Tokens;

namespace WebApp.Pages.Othello
{
    public class Index1Model : PageModel
    {

        public IActionResult OnGet()
        {
            string username = Request.Cookies["Username"];
            if (!username.IsNullOrEmpty())
            {
                return Redirect("./Index");
            }
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Set a cookie to remember the user
            Response.Cookies.Append("Username", "123", new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(7) // Set cookie expiration as needed
            });

            return RedirectToPage("./Register");
        }

      
    }
}
