using System.Runtime.CompilerServices;
using UnityEngine;

public class SplitterDrone : DroneBaseClass
{
    [SerializeField] private float power;
    public override void activate()
    {
        
        //splits into 3 drones by firing 2 others
        Vector2 northEast = new Vector2(0.5f, 0.5f);
        Vector2 southEast = new Vector2(0.5f, -0.5f);
        fireDrone(northEast);
        fireDrone(southEast);
        abilityUsed = true;
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
