using System;

namespace CodeWars
{
    public class Game
    {
        private int[,] Board { get; set; }

        public Game(int[,] board)
        {
            Board = board;
        }

        public static void Main(string[] args)
        {
            int[,] board = { { 1, 1, 0, 0, 0 },
                             { 1, 1, 0, 0, 0 },
                             { 0, 0, 0, 0, 0 },
                             { 0, 0, 0, 1, 1 },
                             { 0, 0, 0, 1, 1 } };
            Game game = new Game(board);
            Console.WriteLine(game.play());
        }

        public int play()
        {
            var leaps = 0;

            for (int y = 0; y < Board.GetLength(1); y++)
            {
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    if (Board[y, x] == 1)
                    {
                        leaps++;
                        RemoveBlock(y, x);
                    }
                }
            }
            return leaps;
        }

        public void RemoveBlock(int y, int x)
        {
            // Flip to zero
            Board[y, x] = 0;
            var length = Board.GetLength(0);

            // Check left
            if (x > 0 && Board[y, x - 1] == 1)
            {
                RemoveBlock(y, x - 1);
            }
            // Check right
            if (x < length - 1 && Board[y, x + 1] == 1)
            {
                RemoveBlock(y, x + 1);
            }
            // Check up
            if (y > 0 && Board[y - 1, x] == 1)
            {
                RemoveBlock(y - 1, x);
            }
            // Check down
            if (y < length - 1 && Board[y + 1, x] == 1)
            {
                RemoveBlock(y + 1, x);
            }
        }
    }
}
