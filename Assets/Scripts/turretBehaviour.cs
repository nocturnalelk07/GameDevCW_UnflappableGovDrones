using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class turretBehaviour : MonoBehaviour
{
    //this is the class for the turret that the player controls

    [SerializeField] private InputActionAsset actions;

    //private Vector2 aimValue;
    private float powerValue;

    private InputAction aimAction;
    private InputAction fireAction;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        aimAction = actions.FindActionMap("Player").FindAction("Move");
        fireAction = actions.FindActionMap("Player").FindAction("Fire");
    }

    private void Update()
    {
        Vector2 aimValue = aimAction.ReadValue<Vector2>();
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
