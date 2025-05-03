using System.Runtime.CompilerServices;
using UnityEngine;

public class SplitterDrone : DroneBaseClass
{
    [SerializeField] private float power;
    private Vector2 northEast = new Vector2(1,1);
    private Vector2 southEast = new Vector2(1,-1);
    public override void activate()
    {
        if(state.GetType() == typeof(DroneFiringState) && !abilityUsed)
        {
            fireDrone(northEast);
            fireDrone(southEast);
            abilityUsed = true;
        }
        //splits into 3 drones by firing 2 others
        
    }

    protected override void destroyEffects()
    {
        
    }

    private void fireDrone(Vector2 direction)
    {
        levelManager.instance.incrementDronesRemaining();
        DroneBaseClass drone = Instantiate(this, transform.position, transform.rotation);
        firingBehaviour.instance.fire(drone, power, direction);
    }

    public void setAbilityUsed()
    {
        abilityUsed = true;
    }
}
