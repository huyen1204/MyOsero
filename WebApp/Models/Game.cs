namespace WebApp.Models
{
    public class Game
    {
        public int[,] Board { get; set; }
        public bool IsPlayer1Turn { get; set; }

        public TimeSpan PlayerOneTime { get; set; }
        public TimeSpan PlayerTwoTime { get; set; }
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }

        private readonly int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        private readonly int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

        public Game()
        {
            Board = new int[8, 8];
            InitializeBoard();
            IsPlayer1Turn = true;
        }

        private void InitializeBoard()
        {
            // Initialize the board with the starting position
            Board[3, 3] = 1;
            Board[3, 4] = 2;
            Board[4, 3] = 2;
            Board[4, 4] = 1;
        }

        public bool MakeMove(int row, int col)
        {
            int player = IsPlayer1Turn ? 1 : 2;
            int opponent = IsPlayer1Turn ? 2 : 1;

            if (Board[row, col] != 0 || !IsValidMove(row, col, player, opponent))
            {
                return false;
            }

            Board[row, col] = player;
            FlipDiscs(row, col, player, opponent);
            IsPlayer1Turn = !IsPlayer1Turn;
            return true;
        }

        private bool IsValidMove(int row, int col, int player, int opponent)
        {
            for (int direction = 0; direction < 8; direction++)
            {
                int x = row + dx[direction];
                int y = col + dy[direction];
                bool foundOpponent = false;

                while (IsWithinBounds(x, y) && Board[x, y] == opponent)
                {
                    foundOpponent = true;
                    x += dx[direction];
                    y += dy[direction];
                }

                if (foundOpponent && IsWithinBounds(x, y) && Board[x, y] == player)
                {
                    return true;
                }
            }
            return false;
        }

        private void FlipDiscs(int row, int col, int player, int opponent)
        {
            for (int direction = 0; direction < 8; direction++)
            {
                int x = row + dx[direction];
                int y = col + dy[direction];
                bool foundOpponent = false;
                List<(int, int)> discsToFlip = new List<(int, int)>();

                while (IsWithinBounds(x, y) && Board[x, y] == opponent)
                {
                    foundOpponent = true;
                    discsToFlip.Add((x, y));
                    x += dx[direction];
                    y += dy[direction];
                }

                if (foundOpponent && IsWithinBounds(x, y) && Board[x, y] == player)
                {
                    foreach (var disc in discsToFlip)
                    {
                        Board[disc.Item1, disc.Item2] = player;
                    }
                }
            }
        }

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }
    }
}
