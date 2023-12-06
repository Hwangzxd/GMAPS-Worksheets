using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        // Loop through each row and column of the 3x3 multiArray
        for (int y = 0; y < 3; y++)      // Do for each row
        {
            for (int x = 0; x < 3; x++)  // Do for each col
            {
                Entries[y, x] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        // your code here
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        // your code here
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        // your code here
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(
        left.Entries[0, 0] + right.Entries[0, 0], left.Entries[0, 1] + right.Entries[0, 1], left.Entries[0, 2] + right.Entries[0, 2],
        left.Entries[1, 0] + right.Entries[1, 0], left.Entries[1, 1] + right.Entries[1, 1], left.Entries[1, 2] + right.Entries[1, 2],
        left.Entries[2, 0] + right.Entries[2, 0], left.Entries[2, 1] + right.Entries[2, 1], left.Entries[2, 2] + right.Entries[2, 2]
        );
        return result; // your code here
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(
        left.Entries[0, 0] - right.Entries[0, 0], left.Entries[0, 1] - right.Entries[0, 1], left.Entries[0, 2] - right.Entries[0, 2],
        left.Entries[1, 0] - right.Entries[1, 0], left.Entries[1, 1] - right.Entries[1, 1], left.Entries[1, 2] - right.Entries[1, 2],
        left.Entries[2, 0] - right.Entries[2, 0], left.Entries[2, 1] - right.Entries[2, 1], left.Entries[2, 2] - right.Entries[2, 2]
        );
        return result; // your code here
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D(
        left.Entries[0, 0] * scalar, left.Entries[0, 1] * scalar, left.Entries[0, 2] * scalar,
        left.Entries[1, 0] * scalar, left.Entries[1, 1] * scalar, left.Entries[1, 2] * scalar,
        left.Entries[2, 0] * scalar, left.Entries[2, 1] * scalar, left.Entries[2, 2] * scalar
        );
        return result; // your code here
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            // Multiplying the entries of the matrix and vector 
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * right.h,
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * right.h
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

        // and so on for another 7 entries
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
    );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // Compare each entry of the matrices
                if (left.Entries[y, x] != right.Entries[y, x])
                    return false;
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // Compare each entry of the matrices
                if (left.Entries[y, x] != right.Entries[y, x])
                    return true;
            }
        }
        return false;
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float getDeterminant()
    //{
    //    return // your code here
    //}

    public void setIdentity()
    {
        //for (int y = 0; y < 3; y++)
        //{
        //    for (int x = 0; x < 3; x++)
        //    {
        //        if (x == y)
        //        {
        //            Entries[y, x] = 1;
        //        }
        //        else
        //        {
        //            Entries[y, x] = 0;
        //        }
        //    }
        //}

        // Loop through each row and column of the 3x3 array
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // If the current row y is equal to the current column x, set the value to 1
                // Else, set it to 0
                Entries[y, x] = x == y ? 1 : 0;
            }
        }  
                 
    }

    public void setTranslationMatrix(float transX, float transY)
    {
        // your code here
        setIdentity();
        // Set the translation matrix entries for the x and y directions
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void setRotationMatrix(float rotDeg)
    {
        // your code here
        setIdentity();
        // Convert the rotation angle from degrees to radians
        float rad = rotDeg * Mathf.Deg2Rad;
        // Set the rotation matrix entries based on the cosine and sine of the angle
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    public void setScalingMatrix(float scaleX, float scaleY)
    {
        // your code here
        setIdentity();
        Entries[0, 0] = scaleX;
        Entries[1, 1] = scaleY;
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
