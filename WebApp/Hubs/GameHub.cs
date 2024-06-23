using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Hubs
{
    public class GameHub : Hub
    {
        //private readonly GameService _gameService;

        //public GameHub(GameService gameService)
        //{
        //    _gameService = gameService;
        //}

        //public async Task MakeMove(int row, int col)
        //{
        //    bool moveMade = _gameService.MakeMove(row, col);
        //    if (moveMade)
        //    {
        //        var game = _gameService.GetGame();
        //        await Clients.All.SendAsync("UpdateGame", game);
        //    }
        //}
        private static Game _game = new Game();

        public async Task MakeMove(int row, int col)
        {
            _game.MakeMove(row, col);
            await Clients.All.SendAsync("UpdateGame", _game);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("UpdateGame", _game);
            await base.OnConnectedAsync();
        }
    }
}
