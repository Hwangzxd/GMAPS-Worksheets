using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.setIdentity();
        mat.Print();

        Question2();
    }

    public void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(2, 1, 3, 0, 1, 4, 2, 3, 2);
        HMatrix2D mat2 = new HMatrix2D(2, 1, 2, 4, 2, 3, 1, 6, 1);
        HVector2D vec1 = new HVector2D(5, 9);
        HMatrix2D resultMat = mat1 * mat2;
        resultMat.Print();
    }

}
