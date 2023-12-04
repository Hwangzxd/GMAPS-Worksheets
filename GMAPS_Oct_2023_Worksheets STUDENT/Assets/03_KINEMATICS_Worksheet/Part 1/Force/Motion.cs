using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        // Calculate the change in position for each axis based on velocity and time
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        // Update the position based on the calculated changes
        transform.position += (new Vector3(dx, dy, dz));
    }
}
