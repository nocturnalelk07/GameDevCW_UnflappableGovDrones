using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(LineRenderer))]
public class droneBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    private float checkTime;
    private string droneStr = "drone";
    //the name of the drone type
    protected string droneName;
    protected Vector2 originalPosition;
    protected Quaternion originalRotation;

    [Header ("state machine")]
    protected IDroneState state = new DroneIdleState();
    protected bool movingPreviously = false;
    protected bool moving = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        state.Enter(this);
        gameObject.layer = LayerMask.NameToLayer(droneStr);
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
    

    private void Update()
    {
        checkTime += Time.deltaTime;
        if (checkTime >= 1)
        {
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

    public Rigidbody2D getRB2D() { return rb2d; }
    public bool getMoving() { return moving; }
    public void setMoving(bool value) { moving = value; } 
    public float getMass() { return rb2d.mass; }
    public IDroneState getState() { return state; }

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

    public void destroyThis()
    {
        Destroy(gameObject);
    }
}
