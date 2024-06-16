using WebApp.Models;

namespace WebApp.Services
{
    public class GameService
    {
        private readonly Game _game;

        public GameService()
        {
            _game = new Game();
        }

        public Game GetGame()
        {
            return _game;
        }

        public bool MakeMove(int row, int col)
        {
            return _game.MakeMove(row, col);
        }
    }
}
