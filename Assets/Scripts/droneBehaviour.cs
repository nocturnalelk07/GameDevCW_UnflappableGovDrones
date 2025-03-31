using UnityEngine;

public class droneBehaviour : MonoBehaviour
{
    [SerializeField] private float droneMass;



    public float getMass()
    {
        return droneMass;
    }
}
