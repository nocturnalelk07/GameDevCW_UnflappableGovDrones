using UnityEngine;

public class TurretReadyState: ITurretState
{
    private const int BaseOnSpriteIndex = 0; 
    public void Enter(turretBehaviour turret)
    {
        //set the turret sprite to the ready sprite
        turret.setBaseSprite(BaseOnSpriteIndex);
    }

    public void Exit(turretBehaviour turret)
    {
        
    }
    public ITurretState Tick(turretBehaviour turret)
    {
        //if the drone has been fired change state
        if (turret.getHasFired())
        {
            return new TurretWaitingState();
        } else
        {
            return null;
        }
            
    }
}
