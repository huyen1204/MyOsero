using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages.Match2
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
