using System;
using System.Threading;

namespace Console_Game
{
    public class EnemyEntity : Entity
    {
        public EnemyEntity(int x, int y, string entityGraphic) : base(x, y, entityGraphic)
        {
            // Wait for a certain amount of time before spawning.
            spawnTimeout = Game.Random.Next(0, ValuesToSetFromScreenSize.MaxEnemySpawnTimer);
        }

        public override void DrawEntity()
        {
            if (spawnTimeout > 0)
            {
                // Return if enemy is waiting to be spawned.
                return;
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            base.DrawEntity();
            Console.ForegroundColor = ConsoleColor.White;
        }

        // "Speed" of each enemy. This is how long an enemy waits before changing coordinates.
        // Also a counter for checking how long it has been since last move.
        private int timeBetweenEachMove = ValuesToSetFromScreenSize.EnemySpeed;
        private int timeSinceLastMove = 0;

        // Declares variable that is used for delaying spawning. 
        // I.e. enemy1 spawns before enemy2, that is set to spawn 50 millisecs after.
        private int spawnTimeout;

        private void CollidedWithEdge()
        {
            if (this.X == 0)
            {
                this.X = Console.WindowWidth-1;
                this.Y = Game.Random.Next(0, Console.WindowHeight);
                
                // Increase score by one for each enemy dodged.
                Game.Score += 1;
            }
        }

        public override void UpdateEntity(int deltaTime)
        {
            // Checks if this instance has hit the left edge.
            CollidedWithEdge();
            
            spawnTimeout -= deltaTime;

            // Returns if the enemy should be inactive.
            if (spawnTimeout > 0)
            {
                return;
            }
            
            timeSinceLastMove += deltaTime;
            
            // Returns if it can't move at the moment. 
            if (timeSinceLastMove < timeBetweenEachMove)
            {
                return;
            }
            
            X -= 1;
            deltaTime -= 30;
            
            timeSinceLastMove -= timeBetweenEachMove;

            base.UpdateEntity(deltaTime);
        }
    }
}