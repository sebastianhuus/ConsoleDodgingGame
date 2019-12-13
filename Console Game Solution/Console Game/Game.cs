using System;
using System.Diagnostics;

namespace Console_Game
{
    // Constructor
    public class Game
    {
        // Instantiates entities.
        public Game()
        {
            // Instantiates random so that it doesn't hold null-value
            Random = new Random();
            
            // Sets the maximum amount of enemies based on the windows' size.
            maxEnemies = ValuesToSetFromScreenSize.MaximumEnemies;
            
            // Instantiates the player.
            player = new PlayerEntity(5,5, "@");
            
            // Creates array for holding enemies.
            enemies = new EnemyEntity[ maxEnemies ];
            
            // Picks a random number of initial enemies.
            CurrentEnemies = Random.Next(2, maxEnemies - 5);
            
            // Instantiates the initial enemies.
            for (int i = 0; i < CurrentEnemies; i++)
            {
                if (enemies[i] == null)
                {
                    InstantiateGenericEnemy(i);
                }
            }

            grapUi = new GUI();
        }
        
        public int CurrentEnemies
        {
            get => _currentEnemies;
            set
            {
                if (value > maxEnemies)
                {
                    throw new Exception("yeet");
                }

                _currentEnemies = value;
                return;
            }
        }

        public bool EnemyInstantiationToggled
        {
            get => _enemyInstantiationToggled;
            set
            {
                if (enemiesToInstantiate != CurrentEnemies) return;

                // If the game allows for instantiating more enemies, flip the variable's value.
                switch (EnemyInstantiationToggled)
                {
                    case true:
                        _enemyInstantiationToggled = false;
                        break;
                    case false:
                        _enemyInstantiationToggled = true;
                        break;
                }
            }
        }

        public static int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        // Player entity
        private PlayerEntity player;
        
        // max: Hardcoded maximal enemy limit.
        // current: Number of enemies we currently have instantiated.
        // enemies: Array that holds our enemies.
        private int maxEnemies;
        private int _currentEnemies;
        private EnemyEntity[] enemies;
        
        // This var is used to create more enemies to add challenge during runtime.
        private int enemiesToInstantiate;
        private bool _enemyInstantiationToggled = false;

        private Stopwatch stopwatch = new Stopwatch();
        public int GameState = 0;

        // This variable can be called by any class in our program. 
        public static Random Random;

        // GUI instance
        private GUI grapUi;
        
        // This variable allows us to make time-dependent stuff
        public int DeltaTime;
        
        // Player's score
        private static int _score;
        
        public void ErrorCheck()
        {
            // Debug-function.
            
            // This function will just double check that no variables are "illegal",
            // i.e. "_currentEnemies" can't be larger than the maximum amount of enemies.

            if (CurrentEnemies > maxEnemies)
            {
                // Yeets an exception if we are supposed to instantiate more enemies 
                // than the maximum amount of enemies ( size of the "enemies"-array. )
                throw new Exception("_currentEnemies is larger than maxEnemies!");
            }
        }

        private void InstantiateGenericEnemy(int index)
        {
            enemies[index] = new EnemyEntity(Console.WindowWidth - 1, Random.Next(0, (Console.WindowHeight - 1)), "o");
        }
        private void CheckIfWeHaveInstantiatedEnoughEnemies(int _howManyEnemiesToInstantiate)
        {
            if (enemiesToInstantiate == CurrentEnemies) EnemyInstantiationToggled = false;
                
            if (EnemyInstantiationToggled) return;

            EnemyInstantiationToggled = true;
            enemiesToInstantiate = _howManyEnemiesToInstantiate;
        }
        
        private void CreateNewEnemies(int deltaTime)
        {
            // Returns if we can't make more enemies.
            if (CurrentEnemies == maxEnemies) return;

            // Random variable to make the creation of new enemies more rare. 
            // This is to balance the game, as it wouldn't
            // be very fun to play with maxEnemies from the start.
            if (Random.Next(0, 1000) != 42) return;
            
            // If current enemies less than max enemies, create one more enemy.
            // (this only executes if the random number above is equal to 42).
            if (CurrentEnemies < maxEnemies)
            {
                // Randomly chooses how many enemies to create.
                CheckIfWeHaveInstantiatedEnoughEnemies(1 + CurrentEnemies);

                for (int i = 0; i < (enemiesToInstantiate); i++)
                {
                    if (enemies[i] == null)
                    {
                        InstantiateGenericEnemy(i);
                        CurrentEnemies += 1;
                    }
                }
            }
        }

        // Should update all things related to the game.
        public void UpdateGameStuff(int deltaTime)
        {
            ErrorCheck();
            
            grapUi.WriteDebugInfo(CurrentEnemies);
            grapUi.WriteScore();
            
            player.UpdateEntity(deltaTime);
            
            // Will roll a random number to see if we should make new enemies.
            // BUT, the loop wil only run if the random value is the magic number 42. :)
            CreateNewEnemies(deltaTime);
            
            // Updates every array element.
            for (int i = 0; i < CurrentEnemies; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].UpdateEntity(deltaTime);
                    
                    // Here we will look for collisions
                    if (player.DetectCollision(enemies[i]))
                    {
                        GameState = 1;
                    }
                }
            }
        }
        
        private void GameOver()
        {
            Console.Clear();
            
            Console.SetCursorPosition(10,10);
            Console.WriteLine("Game Over!");

            System.Threading.Thread.Sleep(2000);
            
            Console.SetCursorPosition(10,12);
            Console.Write("Your score was {0}", Score);
            
            Console.SetCursorPosition(10,14);
            Console.Write("Press any key to continue.");
            
            // Waits for input before exiting, because otherwise the console just exits.
            Console.ReadKey();
        }

        public void Run()
        {
            stopwatch.Start();
            var timeSinceLastFrame = stopwatch.ElapsedMilliseconds;
            
            // Gamestate 1 is the gameover / score screen, while gamestate 0 is going to be the main menu, 
            // if we ever proceed to make one.
            while (GameState >= 2)
            {
                DeltaTime = Convert.ToInt32(stopwatch.ElapsedMilliseconds - timeSinceLastFrame);
                timeSinceLastFrame = (stopwatch.ElapsedMilliseconds);

                UpdateGameStuff(DeltaTime);

                player.DrawEntity();

                for (int i = 0; i < maxEnemies; i++)
                {
                    if (enemies[i] != null)
                    {
                        enemies[i].DrawEntity();
                    }
                }
                
            }

            if (GameState == 1)
            {
                GameOver();
            }
            
        }
    }
}