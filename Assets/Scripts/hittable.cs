using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public abstract class hittable : MonoBehaviour
{
    private const string hittableStr = "hittable";
    protected const string destroyTrigger = "TrDestroy";
    [SerializeField] protected float health;
    protected AudioSource deathSFX;
    private bool noHealthTriggered = false;


    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer(hittableStr);
        deathSFX = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //damage taken is the magnitude of velocity at time of collision
        health -= this.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
        if (health < 0 && !noHealthTriggered)
        {
            noHealthTriggered = true;
            deathSFX.Play();
            noHealth();
        }
    }

    //called when the destroy animation is finished
    public void onDestroyFinished()
    {
        
        afterDestroyComplete();
    }
    protected abstract void afterDestroyComplete();
    //this can be implemented for different behaviour by other scripts
    public abstract void noHealth();
}
    