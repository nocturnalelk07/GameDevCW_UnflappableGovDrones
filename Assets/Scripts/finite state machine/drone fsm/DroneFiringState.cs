using UnityEditor;
using UnityEngine;

public class DroneFiringState : IDroneState
{
    private const string triggerName = "TrFired";
    public void Enter(droneBehaviour drone)
    {
        //firing animation starts
        drone.GetComponent<Animator>().SetTrigger(triggerName);
        return;
    }

    public void Exit(droneBehaviour drone)
    {
        //tell the turret that it has finished firing
        drone.GetComponentInParent<turretBehaviour>().setHasFired(false);

        //garbage collection should handle destruction
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
