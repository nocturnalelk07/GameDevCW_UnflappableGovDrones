using UnityEditor;
using UnityEngine;

public class DroneFiringState : IDroneState
{
    private const string triggerName = "TrFired";
    public void Enter(droneBehaviour drone)
    {
        //firing animation starts
        drone.GetComponent<Animator>().SetTrigger(triggerName);
        drone.getRB2D().gravityScale = 1;
        return;
    }

    public void Exit(droneBehaviour drone)
    {
        //garbage collection should handle destruction
        drone.destroyThis();
        return;
    }

    public IDroneState Tick(droneBehaviour drone)
    {
        if (drone.getMoving())
        {
            return null;
        }
            return new DroneIdleState();
    }

    
}
