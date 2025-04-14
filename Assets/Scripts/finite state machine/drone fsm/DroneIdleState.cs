using UnityEngine;

public class DroneIdleState : IDroneState
{
    public void Enter(droneBehaviour drone)
    {

    }

    public void Exit(droneBehaviour drone)
    {
        
    }

    public IDroneState Tick(droneBehaviour drone)
    {
        return null;
    }
}
