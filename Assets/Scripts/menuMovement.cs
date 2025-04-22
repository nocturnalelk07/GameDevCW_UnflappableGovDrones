using Unity.VisualScripting;
using UnityEngine;

public class menuMovement : MonoBehaviour
{
    [SerializeField] private bool moveRight;
    [SerializeField] private float targetSpeed = 0.1f;
    [SerializeField] private AnimationCurve curve;
    private float time = 0;

    private void Awake()
    {

    }
    private void Update()
    {
        if (moveRight)
        {
            transform.position = transform.position + Vector3.right * targetSpeed * Time.deltaTime * curve.Evaluate(time);
        } else
        {
            transform.position = transform.position - Vector3.right * targetSpeed * Time.deltaTime * curve.Evaluate(time);
        }
        time += Time.deltaTime;
    }
}
