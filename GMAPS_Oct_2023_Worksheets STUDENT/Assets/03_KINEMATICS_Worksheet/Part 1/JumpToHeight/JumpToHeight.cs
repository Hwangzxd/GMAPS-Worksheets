using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        // Using the physics formula for vertical motion to calculate the initial velocity needed for the jump
        float u = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.magnitude) * Height);
        // Set the Rigidbody's velocity to the new vector in the upward direction
        rb.velocity = new Vector3(0, u, 0);

        //float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Trigger jump when space key is pressed
            Jump();
        }
    }
}

