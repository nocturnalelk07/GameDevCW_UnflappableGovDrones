using UnityEngine;

public class droneBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public float getMass()
    {
        return rb2d.mass;
    }
}
