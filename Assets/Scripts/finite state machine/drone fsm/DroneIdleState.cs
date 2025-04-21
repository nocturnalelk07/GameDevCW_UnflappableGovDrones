using UnityEngine;

public class DroneIdleState : IDroneState
{
    public void Enter(DroneBaseClass drone)
    {
        Debug.Log("drone idle state for " + drone.getDroneType());
        drone.getRB2D().gravityScale = 0;
        return;
    }

    public void Exit(DroneBaseClass drone)
    {
        return;
    }

    public IDroneState Tick(DroneBaseClass drone)
    {
        if (drone.getIsMoving())
        {
            return new DroneFiringState();
        }

        return null;
    }
}
