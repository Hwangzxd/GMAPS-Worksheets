using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing

        if (Input.GetMouseButtonDown(0))
        {
            //var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            // Check if there is a ball and if the mouse click is colliding with the ball
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                // Draw a line between the mouse position and the ball
                drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 1f, Color.black);
                drawnLine.EnableDrawing(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(ball.transform.position.x - drawnLine.transform.position.x, ball.transform.position.y - drawnLine.transform.position.y);
            ball.Velocity = v;

            drawnLine = null; // End line drawing            
        }

        // If a line is being drawn, update its end point to the current mouse position
        if (drawnLine != null)
        {
            drawnLine.end = startLinePos; // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
