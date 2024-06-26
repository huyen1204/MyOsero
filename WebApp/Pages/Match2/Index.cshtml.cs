using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Xml.Linq;
using WebApp.Hubs;
using WebApp.Models;

namespace WebApp.Pages.Match2
{
    public class IndexModel : PageModel
    {
        private readonly IHubContext<GameHub> _hubContext;

        public IndexModel(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [BindProperty]
        public Game Game { get; set; }


        public void OnGet()
        {
            
            Game = new Game();
        }

        public async Task OnPostMakeMove(int row, int col)
        {
            Game.MakeMove(row, col);
            await _hubContext.Clients.All.SendAsync("UpdateGame", Game);
            //return Page();
        }
    }
}
