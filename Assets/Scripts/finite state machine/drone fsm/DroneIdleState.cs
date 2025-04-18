using UnityEngine;

public class DroneIdleState : IDroneState
{
    public void Enter(droneBehaviour drone)
    {
        drone.getRB2D().gravityScale = 0;
        return;
    }

    public void Exit(droneBehaviour drone)
    {
        return;
    }

    public IDroneState Tick(droneBehaviour drone)
    {
        if (drone.getMoving())
        {
            return new DroneFiringState();
        }

        return null;
    }
}
