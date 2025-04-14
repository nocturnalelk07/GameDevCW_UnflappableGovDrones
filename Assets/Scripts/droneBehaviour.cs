using UnityEngine;

public class droneBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Header ("state machine")]
    private IDroneState state = new DroneIdleState();

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
        if (state.GetType() == typeof(DroneIdleState))
        {
            Debug.Log("drone is idle");
        }
        //updateState();
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

}
