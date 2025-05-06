using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof (LineRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public abstract class DroneBaseClass : MonoBehaviour
{//the subclass sandbox base class for drones in the game

    [Header ("required components")]
    protected Rigidbody2D rb2d;
    protected CircleCollider2D circleCollider;
    protected LineRenderer lineRenderer;
    protected Animator animator;
    protected AudioSource deathSound;

    [Header("finite state machine")]
    protected IDroneState state = new DroneIdleState();
    protected bool isMoving = false;
    private float movingThreshold = 0.2f;

    [Header("other")]
    [SerializeField] protected float droneMass;
    [SerializeField] protected string droneType;
    protected bool abilityUsed = false;
    protected const string destroyTrigger = "TrDestroy";

    //concrete unity method implementations
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
        rb2d.mass = droneMass;
        levelManager.instance.decrementDronesRemaining();
    }
    private void Start()
    {
        state.Enter(this);
        startAbstract();
    }
    private void Update()
    {
        updateState();
    }

    //abstract methods
    //this is the method that drones will implement for activating any abilities they have
    public abstract void activate();
    //plays the animation, sound effect etc for when the drone destroys itself
    protected abstract void destroyEffects();
    protected abstract void startAbstract();

    //concrete methods
    //updates the state of the drone
    protected void updateState()
    {
        checkIsMoving();
        //updates the finite state machine
        IDroneState newState = state.Tick(this);

        if (newState != null)
        {
            state.Exit(this);
            state = newState;
            newState.Enter(this);
        }
    }

    //checks if the drone is moving
    private void checkIsMoving()
    {
        //not a very sophisticated check but 
        if (rb2d.linearVelocity.magnitude <= movingThreshold)
        {
            isMoving = false;
            return;
        }
            isMoving = true; 
    }

    //public methods, getters and setters
    public Rigidbody2D getRB2D() { return rb2d; }
    public bool getIsMoving() { return isMoving; }
    public void destroyThis() 
    {
        //calls the trigger to start the destroy animation
        deathSound.Play();
        animator.SetTrigger(destroyTrigger);
        destroyEffects();
    }
    public void OnDestroyFinished()
    {
        //handles destruction effects once the animation is finished
        
        levelManager.instance.checkGameOver();
        Destroy(gameObject);
    }
    public IDroneState getState() { return state; }
    public float getMass() { return rb2d.mass; }
    public LineRenderer GetLineRenderer() { return lineRenderer; }
    public Animator GetAnimator() { return animator; }
    public string getDroneType() { return droneType; }
}
