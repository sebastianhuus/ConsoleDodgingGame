using System;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Console_Game
{
    public class PlayerEntity : Entity
    {
        // This class is responsible for the player...
        
        // WASD and arrow keys should move the player around. 
        // We need a way to give new x and y values for the player object.

        // Constructor for sub-class-object.
        public PlayerEntity(int x, int y, string entityGraphic) : base(x, y, entityGraphic)
        {
            // Doesn't do anything because we use our parent's constructor   
        }

        private void GetInput()
        {
            // This takes input as long as the player slaps a key. :)
            if (!Console.KeyAvailable) return;
            
            var playerInput = Console.ReadKey(true).Key;
            switch (playerInput)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    this.Y -= 1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    this.Y += 1;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    this.X -= 1;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    this.X += 1;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        // This overrides its' parent function when we call "UpdateEntity".
        public override void UpdateEntity(int deltaTime)
        {
            // Here, we will get input from the player.
            GetInput();
            
            base.UpdateEntity(deltaTime);
        }

    }
}