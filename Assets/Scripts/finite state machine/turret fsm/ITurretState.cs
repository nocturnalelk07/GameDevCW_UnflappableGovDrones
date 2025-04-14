using Unity.VisualScripting;
using UnityEngine;

public interface ITurretState
{
    public ITurretState Tick(turretBehaviour turret);
    public void Enter(turretBehaviour turret);
    public void Exit(turretBehaviour turret);
}
