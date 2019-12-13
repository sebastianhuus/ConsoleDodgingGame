/// <summary>
/// This class sets variables based on the computers display dimensions.
/// </summary>

using System;

namespace Console_Game
{
    public static class ValuesToSetFromScreenSize
    {
        public static void SetValues()
        {
            // this method balances the game based on window size.
            
            if (WindowHeight < 40)
            {
                MaximumEnemies = 50;
            }
            else if (WindowHeight < 100)
            {
                MaximumEnemies = 70;
            }
            else
            {
                MaximumEnemies = 50;
            }

            if (WindowWidth > 100)
            {
                EnemySpeed = 30;
                MaxEnemySpawnTimer = 10000;
            }
            else if (WindowWidth > 40)
            {
                EnemySpeed = 50;
                MaxEnemySpawnTimer = 8000;
            }
            else
            {
                EnemySpeed = 50;
                MaxEnemySpawnTimer = 5000;
            }
        }
        
        public static int MaximumEnemies = 10;
        public static int EnemySpeed = 30;
        public static int MaxEnemySpawnTimer = 1000;

        public static int WindowWidth = 130;
        public static int WindowHeight = 30;
    }
}