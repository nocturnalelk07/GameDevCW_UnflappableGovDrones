using UnityEngine;

public class DropDrone : DroneBaseClass
{
    //this drone drops downwards with force when activated
    public override void activate()
    {
        if (!abilityUsed && state.GetType() == typeof(DroneFiringState))
        {
            firingBehaviour.instance.fire(this, 100, Vector2.down);
            abilityUsed = true;
        }
        
    }

    protected override void destroyEffects()
    {
    }

    protected override void startAbstract()
    {
    }
}
