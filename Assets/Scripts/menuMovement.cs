using UnityEngine;

public class menuMovement : MonoBehaviour
{
    [SerializeField] private bool moveRight;
    [SerializeField] private float moveDistance = 0.1f;
    private void FixedUpdate()
    {
        if (moveRight)
        {
            transform.position = transform.position + Vector3.right * moveDistance * Time.fixedDeltaTime;
        } else
        {
            transform.position = transform.position - Vector3.right * moveDistance * Time.fixedDeltaTime;
        }
    }
}
