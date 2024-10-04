using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 15f;
    public float randSpeedRange = 3f;

    public LayerMask layerMask; 

    public float radius = 20f;

    private new Rigidbody rigidbody;

    private (Transform transform, Rigidbody rigidbody) target;

    private float currentSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        currentSpeed = Random.Range(speed - randSpeedRange * 0.5f, speed + randSpeedRange * 0.5f);
    }

    private void Update()
    {
        if (target.transform != null)
        {
            Vector3 delta = target.transform.position - transform.position;

            Vector3 direction = new Vector3(delta.x, 0f, delta.z).normalized;

            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        Transform transform = null;

        Collider[] colliders = Physics.OverlapSphere(rigidbody.position, radius, layerMask);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                transform = collider.transform;
            }
        }

        if (target.transform != transform)
        {
            target.transform = transform;
            target.rigidbody = null;

            if (transform != null)
            {
                target.rigidbody = transform.GetComponent<Rigidbody>();
            }
        }

        if (target.rigidbody != null)
        {
            Vector3 delta = target.rigidbody.position - rigidbody.position;

            Vector3 direction = new Vector3(delta.x, 0f, delta.z).normalized;

            rigidbody.velocity = direction * currentSpeed + new Vector3(0f, rigidbody.velocity.y, 0f);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
