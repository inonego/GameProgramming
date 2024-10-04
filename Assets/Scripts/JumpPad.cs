using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float force = 40f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
