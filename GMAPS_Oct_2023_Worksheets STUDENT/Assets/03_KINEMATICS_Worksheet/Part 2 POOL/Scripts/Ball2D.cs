using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        // Calculate the distance between the object's current position and the specified point
        float distance = Vector2.Distance(transform.position, new Vector2(x, y));
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        // Calculate the displacement in the x and y directions based on the ball's velocity and time
        float displacementX = Velocity.x * Time.deltaTime;
        float displacementY = Velocity.y * Time.deltaTime;

        // Update the ball's position by adding displacements
        Position.x += displacementX;
        Position.y += displacementY;

        // Update the transform position
        transform.position = new Vector2(Position.x, Position.y);
    }
}

