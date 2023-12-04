using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        // Using the formula for Euclidean distance, calculate the squared differences
        // in x and y coordinates then find the square root of their sum
        return Mathf.Sqrt((p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y));
    }
}

