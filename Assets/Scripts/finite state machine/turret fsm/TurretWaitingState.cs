using UnityEngine;


//state for a turret that has fired and is waiting to reload
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
        //if the turret is allowed to fire
        if (turret.canFire())
        {
            return new TurretReadyState();
        }
        else
        {
            return null;
        }
    }
}
