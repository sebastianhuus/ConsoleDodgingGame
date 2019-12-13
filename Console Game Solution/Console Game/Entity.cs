using System;
using System.Diagnostics;

namespace Console_Game
{
    // I don't want to instantiate a "neutral" entity. Should always be player or enemy.
    // Therefore, this class is abstract.
    public abstract class Entity
    {
        // Entities need x and y coordinates and a symbol to be drawn, and perhaps even a color.
        public Entity(int x, int y, string symbol)
        {
            this.X = x;
            this.Y = y;
            this.EntityGraphic = symbol;
        }
        
        // Constructs a new object WITH a color parameter, if that is provided.
        // Accessors for position-variables
        public int X
        {
            get => _x;
            set
            {
                // If the value is within the window size, change the value of x.
                if (value >= 0 && value <= Console.WindowWidth-1)
                {
                    this.UndrawEntity();
                    _x = value;
                }
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                if (value >= 0 && value <= Console.WindowHeight-2)
                {
                    UndrawEntity();
                    _y = value;
                }
            }
        }
        
        // OPTIMIZE UNDRAW-DRAW MECHANICS
        
        // Constructor variables
        private int _x;
        private int _y;
        private string EntityGraphic;

        // All entities should have a function to draw themselves in the console.
        public virtual void DrawEntity()
        {
            Console.SetCursorPosition(this.X, Y);
            Console.Write(this.EntityGraphic);
        }

        // This undraws the entity, and is called whenever it changes position. 
        public void UndrawEntity()
        {
            Console.SetCursorPosition(this.X,this.Y );
            Console.Write(' ');
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        // We need a function for detecting collisions between entities.
        public bool DetectCollision(Entity other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        // Virtual methods can be overriden by child objects.
        public virtual void UpdateEntity(int deltaTime)
        {
            // Does nothing atm.
        }
    }
}