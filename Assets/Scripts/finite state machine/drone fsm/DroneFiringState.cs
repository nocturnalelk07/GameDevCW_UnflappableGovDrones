using UnityEditor;
using UnityEngine;

public class DroneFiringState : IDroneState
{
    private const string triggerName = "TrFired";
    public void Enter(DroneBaseClass drone)
    {
        //firing animation starts
        drone.GetAnimator().SetTrigger(triggerName);
        drone.getRB2D().gravityScale = 1;
        return;
    }

    public void Exit(DroneBaseClass drone)
    {
        //destroys the drone, not the most efficient option but that wont be an issue with so few drones, a possible candidate for the object pooling pattern
        drone.destroyThis();
        return;
    }

    public IDroneState Tick(DroneBaseClass drone)
    {
        if (drone.getIsMoving())
        {
            return null;
        }
            return new DroneIdleState();
    }

    
}
