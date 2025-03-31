using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class turretBehaviour : MonoBehaviour
{
    //this is the class for the turret that the player controls

    [SerializeField] private int MAXIMUM_POWER = 100;
    [SerializeField] private int MINIMUM_POWER = 10;
    private const string ACTION_MAP_NAME = "Player";
    private const string MOVE_ACTION = "Move";
    private const string FIRE_ACTION = "Fire";
    private const string POWER_ACTION = "Power";
    private const string DRONENAME = "drone";

    [SerializeField] private GameObject turret;
    private SpriteUpdateBehaviour turretSpriteUpdater;
    private Sprite[] turretBarrelSpriteArray;

    [SerializeField] private int rotationalSpeed;

    //player input variables
    [SerializeField] private InputActionAsset actions;
    private float powerValue;
    private float powerInput;
    private float powerPercent;
    private int turretSpriteIndex;
    private Vector3 aimValue = new Vector3();
    private InputAction aimAction;
    private InputAction fireAction;

    [Header("drone Firing variables")]
    [SerializeField] private droneBehaviour equippedDrone;
    [SerializeField] private firingBehaviour firingBehaviour;
    [SerializeField] private LineRenderer lineRenderer;

    [Header("other")]
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject barrelPivotPoint;

    private void Awake()
    {
        powerValue = MINIMUM_POWER;
        aimAction = actions.FindActionMap(ACTION_MAP_NAME).FindAction(MOVE_ACTION);
        fireAction = actions.FindActionMap(ACTION_MAP_NAME).FindAction(FIRE_ACTION);
        fireAction.performed += Fire;
        rb2d = GetComponent<Rigidbody2D>();
        turretSpriteUpdater = turret.GetComponent<SpriteUpdateBehaviour>();
    }

    private void Start()
    {
        turretBarrelSpriteArray = turretSpriteUpdater.getSprites();
    }

    private void FixedUpdate()
    {
        //The y input adjusts the aim of the turret (up or down angle) 
        aimValue.z = aimAction.ReadValue<Vector2>().y;
        barrelPivotPoint.transform.Rotate(aimValue * Time.deltaTime * rotationalSpeed);

        //the x input controls the power of the turret (left or right distance)
        powerInput = aimAction.ReadValue<Vector2>().x;
        if (powerInput != 0) 
        {
            OnAdjustPower();
        }
        drawProjection();
        
    }

    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }

    //handles everything the turret should do when the player adjusts the power
    private void OnAdjustPower()
    {
        //add the user's input to the power of the turret, making sure it is within bounds
        powerValue += powerInput;
        if (powerValue > MAXIMUM_POWER)
        {
            powerValue = MAXIMUM_POWER;
        }
        if (powerValue < MINIMUM_POWER)
        {
            powerValue = MINIMUM_POWER;
        }

        //update the turret sprite to show the change in power on the gun

        //first work out the % of the maximum power as a decimal
        powerPercent = powerValue / MAXIMUM_POWER;

        //then we work out what index in the array of sprites to use
        turretSpriteIndex = (int)((turretBarrelSpriteArray.Length - 1) * powerPercent);
        Debug.Log("power is: " + powerValue + " index is: " + turretSpriteIndex);

        //finally we set the sprite with the calculated index
        turretSpriteUpdater.setSprite(turretSpriteIndex);
    }

    public void Fire(InputAction.CallbackContext context)
    {
    }

    private void drawProjection() 
    {
        if(fireAction.IsPressed())
        {
            firingBehaviour.drawLine(lineRenderer, equippedDrone.transform, powerValue, equippedDrone.getMass());
        } else
        {
            lineRenderer.enabled = false;
        }
        
    }
}
