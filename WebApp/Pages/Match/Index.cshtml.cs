using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages.Match
{
    public class IndexModel : PageModel
    {
        private readonly GameService _gameService;

        public Game Game { get; private set; }

        public IndexModel(GameService gameService)
        {
            _gameService = gameService;
        }

        public void OnGet()
        {
            Game = _gameService.GetGame();
        }

        public IActionResult OnPostMakeMove(int row, int col)
        {
            _gameService.MakeMove(row, col);
            Game = _gameService.GetGame();
            return RedirectToPage("./Index");
        }
    }
}

