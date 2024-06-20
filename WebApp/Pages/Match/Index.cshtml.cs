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
        public List<int> Board { get; set; }

        [BindProperty]
        public bool IsPlayer1Turn { get; set; }

        public void OnGet()
        {
            var game = new Game();
            Board = game.Board;
            IsPlayer1Turn = game.IsPlayer1Turn;
        }

        public IActionResult OnPostMakeMove(int row, int col)
        {
            var game = new Game(Board, IsPlayer1Turn);
            game.MakeMove(row, col);
            Board = game.Board;
            IsPlayer1Turn = game.IsPlayer1Turn;
            return Page();
        }
    }
}

