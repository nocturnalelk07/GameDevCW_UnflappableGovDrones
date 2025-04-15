using System.Collections;
using UnityEngine;

public class droneBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float checkTime;

    [Header ("state machine")]
    private IDroneState state = new DroneIdleState();
    private bool movingPreviously = false;
    private bool moving = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        state.Enter(this);
    }
    public float getMass()
    {
        return rb2d.mass;
    }

    private void Update()
    {
        checkTime += Time.deltaTime;
        if (checkTime >= 1)
        {
            Debug.Log("check moving");
            checkMoving();
        }
        
        updateState();
    }

    private void updateState()
    {
        //updates the finite state machine
        IDroneState newState = state.Tick(this);

        if (newState != null)
        {
            state.Exit(this);
            state = newState;
            newState.Enter(this);
        }
    }

    public Rigidbody2D getRB2D()
    {
        return rb2d;
    }

    public bool getMoving()
    {
        return moving;
    }

    public bool checkMoving()
    {
        checkTime = 0f;
        if (rb2d.linearVelocity.magnitude <= 0.1)
        {
            if (!movingPreviously) 
            {
                moving = false;
            } else
            {
                movingPreviously = false;
            }
            
        } else
        {
            movingPreviously = true;
            moving = true;
        }
        
        return moving;
    }

}
