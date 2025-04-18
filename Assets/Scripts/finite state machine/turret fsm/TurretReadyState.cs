using UnityEngine;

//state for a turret that is ready to fire
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
        //if the turret is unable to fire
        if (!turret.canFire())
        {
            return new TurretWaitingState();
        } else
        {
            return null;
        }
            
    }
}
