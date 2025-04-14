using Unity.VisualScripting;
using UnityEngine;

public interface IDroneState
{
    public IDroneState Tick(droneBehaviour drone);
    public void Enter(droneBehaviour drone);
    public void Exit(droneBehaviour drone);
}
