using UnityEngine;

public class BasicDrone : droneBehaviour
{
    SerializeField droneMass;

    private void Awake()
    {
        getRB2D();
    }
    //this is the basic drone, it doesnt do anything special and is fairly heavy
}
