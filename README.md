# ConsoleDodgingGame
 Her skal du unngå fiender ( o-er ) og du spiller som en alfakrøll ( @ )

Du kan spille med piltastene eller med WASD
Spillet setter størrelsen på vinduet automatisk. Det kan hende noe ikke funker som det skal hvis du endrer størrelsen selv.  
Når vinduet er i fokus, trykk Enter-tasten en gang eller to for å starte spillet. Du kan ikke "vinne", men du kan få en score. 
Spillet kjører bare 1 gang. Når man taper, lukkes vinduet etter at man trykker en tast. 

Du finner selve spillet (uten source code ) under \Spill. Spillet tar ca. 200 mb fordi det er self-contained og inneholder alle nødvendige c# libraries. 

**Du må tillate at .exe filen kjøres, fordi Windows blokkerer den automatisk :((**

## Source code
Du finner selve c# solutionen under \Console Game Solution.
Hvis du vil titte på enkelte filer, finner du de under "\Console Game Solution\Console Game".

Filen "MiscEntities.cs" er ubrukt, men var ment til å holde på andre objekter enn fiender og players. Planen var å ha et objekt som kunne "spille ping pong" med fiendene; dvs. å slå dem motsatt vei slik at spilleren må unngå fiender fra høyre og venstre side. 

### Showcase av litt kode
```c#  
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
```
