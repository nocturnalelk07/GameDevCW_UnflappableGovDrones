using Mono.Cecil.Cil;
using System;
using UnityEngine;



public class firingBehaviour : MonoBehaviour
{
    //singleton script that holds the methods required for a drone being fired, mostly from the railgun but also in some other cases

    public static firingBehaviour instance { get; private set; }

    private Vector3 startPosition;
    private Vector3 startVelocity;
    private Vector3 point;
    [Header("display controls")] //these affect how smooth the line appears
    [SerializeField][Range(10, 100)] private int linePoints = 25;
    [SerializeField][Range(0.01f, 0.25f)] private float timeBetweenPoints = 0.1f;

    //variables for firing the turret
    Vector2 fireForceDirection;
    private float droneMass;
    private LayerMask collisionLayerMask;

    public void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void fire(DroneBaseClass drone, float power) 
    {

        Vector2 fireForceDirection = drone.transform.right;
        fireForceDirection.x *= power;
        fireForceDirection.y *= power;

        drone.getRB2D().gravityScale = 1;
        drone.getRB2D().AddForce(fireForceDirection, ForceMode2D.Impulse);
    }

    //uses suvat equations to calculate a trajectory.
    public void drawLine(LineRenderer lr, float force, DroneBaseClass drone)
    {
        droneMass = drone.getMass();
        Transform firingPosition = drone.transform;
        lr.enabled = true;
        lr.positionCount = Mathf.CeilToInt(linePoints / timeBetweenPoints) + 1;
        startPosition = firingPosition.position;
        startVelocity = force * firingPosition.right / droneMass;
        int i = 0;
        lr.SetPosition(i, startPosition);
        for (float time = 0; time < linePoints; time += timeBetweenPoints)
        {
            i++;
            point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

            lr.SetPosition(i, point);
        }
    }
}
