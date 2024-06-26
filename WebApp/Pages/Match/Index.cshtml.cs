using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages.Match
{
    public class IndexModel : PageModel
    {
        
        public IndexModel()
        {
        }

        [BindProperty]
        public Game Game { get; set; }

    
        public void OnGet()
        {
            Game = new Game();
        }

        public IActionResult OnPostMakeMove(int row, int col)
        {
            Game.MakeMove(row, col);

            return Page();
        }
    }
}

