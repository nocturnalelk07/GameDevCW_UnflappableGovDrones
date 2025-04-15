using UnityEditor;
using UnityEngine;

public class DroneFiringState : IDroneState
{
    public void Enter(droneBehaviour drone)
    {
        //firing animation starts
        
        return;
    }

    public void Exit(droneBehaviour drone)
    {
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
