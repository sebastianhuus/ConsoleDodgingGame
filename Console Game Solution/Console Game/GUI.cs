using System;

namespace Console_Game
{
    public class GUI
    {
        public GUI()
        {
        }

        public int X
        {
            get => _x;

            set { this._x = value; }
        }

        public int Y
        {
            get => _y;

            set { this._y = value; }
        }

        private int _x;
        private int _y;

        public void WriteScore()
        {
            Console.SetCursorPosition(Console.WindowWidth - 15, Console.WindowHeight - 1);
            Console.Write("Score: {0}", Game.Score);
        }

        public void WriteDebugInfo(int currentEnemies)
        {
            Console.SetCursorPosition(0, Console.WindowHeight-1);
            Console.Write("Current enemies: {0}", currentEnemies);
        }
    }
}