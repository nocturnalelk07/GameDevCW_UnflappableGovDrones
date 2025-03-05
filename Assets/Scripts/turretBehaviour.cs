using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class turretBehaviour : MonoBehaviour
{
    //this is the class for the turret that the player controls

    private const int MAXIMUM_POWER = 100;
    private const string ACTION_MAP_NAME = "Player";
    private const string MOVE_ACTION = "Move";
    private const string FIRE_ACTION = "Fire";
    private const string POWER_ACTION = "Power";

    [SerializeField] private int rotationalSpeed;

    //player input variables
    [SerializeField] private InputActionAsset actions;
    private float powerValue;
    private Vector3 aimValue = new Vector3();
    private InputAction aimAction;
    private InputAction fireAction;
    private InputAction powerAction;


    private Rigidbody2D rb2d;
    [SerializeField] private GameObject barrelPivotPoint;

    private void Awake()
    {
        aimAction = actions.FindActionMap(ACTION_MAP_NAME).FindAction(MOVE_ACTION);
        fireAction = actions.FindActionMap(ACTION_MAP_NAME).FindAction(FIRE_ACTION);
        powerAction = actions.FindActionMap(ACTION_MAP_NAME).FindAction(POWER_ACTION);
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //we get the vector of the player's input each frame.
        //The y adjusts the aim of the turret (up down angle) the x controls power of the turret (left right distance)

        aimValue.z = aimAction.ReadValue<Vector2>().y;
        barrelPivotPoint.transform.Rotate(aimValue * Time.deltaTime * rotationalSpeed);
        powerValue += aimAction.ReadValue<Vector2>().x;
        if (powerValue > MAXIMUM_POWER ) 
        {
            powerValue = MAXIMUM_POWER;
        }
        Debug.Log(aimValue);



    }

    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }
}
