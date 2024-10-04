using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public LayerMask layerMask;

    public int damage = 1;

    public int penetration = -1;

    private new Rigidbody rigidbody;

    private int hitCount = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.includeLayers = +layerMask;
        rigidbody.excludeLayers = ~layerMask;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

        hitCount++;

        if (penetration >= 0)
        {
            if (hitCount >= penetration)
            {
                Destroy(gameObject);
            } 
        }
    }
}
