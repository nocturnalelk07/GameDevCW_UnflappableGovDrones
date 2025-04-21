using Unity.VisualScripting;
using UnityEngine;

public interface IDroneState
{
    public IDroneState Tick(DroneBaseClass drone);
    public void Enter(DroneBaseClass drone);
    public void Exit(DroneBaseClass drone);
}
