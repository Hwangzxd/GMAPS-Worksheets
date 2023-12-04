using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Apply force to the Rigidbody using the specified force vector
        rb.AddForce(force, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

