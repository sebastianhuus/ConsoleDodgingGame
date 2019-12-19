/// <summary>
/// Just a holder for our main()-loop
/// </summary>

using System;

namespace Console_Game
{
    class Program
    {
        static void Main()
        {
            // Clears console in case threre is stuff there already. 
            Console.Clear();
            // Hides the input-cursor when writing in the console.
            Console.CursorVisible = false;

            Console.SetWindowSize(ValuesToSetFromScreenSize.WindowWidth, ValuesToSetFromScreenSize.WindowHeight);

            Console.BufferWidth = Console.WindowWidth; 
            Console.BufferHeight = Console.WindowHeight;
            
            ValuesToSetFromScreenSize.SetValues();
            
            // Instantiates a new object of type Game,
            // which allows us to call functions from the game-class.
            Game game = new Game();
            
            Console.SetCursorPosition(10,8);
            Console.WriteLine("Use WASD or arrow keys to move the '@' character");
            
            Console.SetCursorPosition(10,10);
            Console.WriteLine("Press enter to start!");
            
            Console.SetCursorPosition(10,11);
            Console.Write("Remember to set the window to fullscreen!");
            
            // Wait while the user gets ready.
            while (true)
            {
                // Don't do anything
                if (Console.ReadKey(true).Key == ConsoleKey.Enter) break;
            }

            Console.Clear();
            
            // Starts the game loop.
            game.GameState = 2;
            game.Run();
        }
    }
}