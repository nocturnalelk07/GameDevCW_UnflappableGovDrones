using UnityEngine;

public class TurretWaitingState : ITurretState
{
    private const int BaseOnSpriteIndex = 1;

    public void Enter(turretBehaviour turret)
    {
        turret.setBaseSprite(BaseOnSpriteIndex);
    }

    public void Exit(turretBehaviour turret)
    {
        
    }

    public ITurretState Tick(turretBehaviour turret)
    {
        //if the drone has been fired change state
        if (!turret.getHasFired())
        {
            return new TurretReadyState();
        }
        else
        {
            return null;
        }
    }
}
