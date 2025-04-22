using UnityEngine;

public class OtherDrone : DroneBaseClass
{
    public override void activate()
    {
        //do something really special
        if (state.GetType() == typeof(DroneFiringState))
        {
            //only activate if the drone has been fired
            Debug.Log("activate while flying!");
        }
    }

    protected override void destroyEffects()
    {
        
    }
}
