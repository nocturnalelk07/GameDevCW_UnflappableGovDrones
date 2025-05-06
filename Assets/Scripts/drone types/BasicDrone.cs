using UnityEngine;

public class BasicDrone : DroneBaseClass
{//this is the basic drone, it doesnt do anything special, essentially implements the base class

    public override void activate()
    {
        //do nothing because this is a basic drone
    }

    protected override void destroyEffects()
    {
        //nothing for now
    }

    protected override void startAbstract()
    {
    }
}
