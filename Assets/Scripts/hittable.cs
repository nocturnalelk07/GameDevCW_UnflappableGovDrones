using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public abstract class hittable : MonoBehaviour
{
    private const string hittableStr = "hittable";
    [SerializeField] protected float health;


    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer(hittableStr);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //damage taken is the magnitude of velocity at time of collision
        health -= this.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
        Debug.Log(health);
        if (health < 0)
        {
            noHealth();
        }
    }

    //this can be implemented for different behaviour by other scripts
    public abstract void noHealth();

}
    