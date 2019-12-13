using System;

namespace Console_Game
{
    public class MiscEntities : Entity
    {
        // These entities can play pong with the enemies
        // and make enemies bounce towards you.
        // They should spawn on the left side of the screen.
        
        // I think they should be 3 cells tall and 1 wide, so maybe we should
        // instantiate them as 3 individual objects?
        
        // todo Should we make a subclass of this class again, named "ping pongs"?

        public MiscEntities(int x, int y, string entityGraphic) : base(x, y, entityGraphic)
        {
            // Empty constructor atm
        }
    }
}