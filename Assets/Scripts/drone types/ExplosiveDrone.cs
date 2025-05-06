using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class ExplosiveDrone : DroneBaseClass
{
    private Camera _camera;
    private Vector3 origin;
    [SerializeField] private float duration = 1;
    [SerializeField] private float magnitude = 0.1f;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForceMultiplier;
    Collider2D[] inExplosion = null;
    
    public override void activate()
    {
        if (!abilityUsed && state.GetType() == typeof(DroneFiringState))
        {
            destroyThis();
        }
    }


    protected override void destroyEffects()
    {
        explosionEffects();
    }

    protected override void startAbstract()
    {
        _camera = Camera.main;
        origin = _camera.transform.position;
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

    }

    private void explosionEffects()
    {
        StartCoroutine(CameraShake());
    }

    private IEnumerator CameraShake()
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            x = origin.x + x;
            float y = Random.Range(-1f, 1f) * magnitude;
            y = origin.y + y;
            _camera.transform.position = new Vector3(x, y, origin.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        _camera.transform.position = origin;
    }
}
