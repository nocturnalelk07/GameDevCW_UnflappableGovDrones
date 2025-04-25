using UnityEngine;

public class ExplosiveDrone : DroneBaseClass
{
    
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForceMultiplier;
    Collider2D[] inExplosion = null;
    
    public override void activate()
    {
        if (!abilityUsed)
        {
            explode();
            abilityUsed = true;
        }
    }

    protected override void destroyEffects()
    {
    }
    
    private void explode()
    {
        inExplosion = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D col in inExplosion)
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 distanceVector = rb.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    float explosionForce = explosionForceMultiplier * distanceVector.magnitude;
                    rb.AddForce(distanceVector.normalized * explosionForce);
                }
            }
        }

        explosionEffect();
    }

    private void explosionEffect()
    {
        //particle effects for explosion here
    }
    
}
