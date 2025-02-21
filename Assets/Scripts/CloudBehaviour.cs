using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    [SerializeField] private int moveSpeedMultiplier = 10;
    [SerializeField] private float deadZone = 16;

    private float moveSpeed;
    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        moveSpeed = Random.value * moveSpeedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        //go back to starting position if it passes the screen
        if (transform.position.x > deadZone)
        {
            transform.position = startingPosition;
        }
    }
}
