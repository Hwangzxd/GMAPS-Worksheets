// Uncomment this whole file.

//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        // Your code here
        Translate(1, 1);
        //Rotate(45);
    }


    void Translate(float x, float y)
    {
        // Your code here
        // Reset the transform matrix to the identity matrix
        transformMatrix.setIdentity();
        // Set the translation part of the transform matrix
        transformMatrix.setTranslationMatrix(x, y);
        Transform();

        // Update the position vector by multiplying it with the transform matrix
        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginalMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        // Set the translation matrices for moving to and from the center of rotation 
        toOriginMatrix.setTranslationMatrix(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMatrix(pos.x, pos.y);

        // Set the rotation matrix based on an angle
        rotateMatrix.setRotationMatrix(angle);

        transformMatrix.setIdentity();
        // Combine the transformation matrices to get the rotation around the specified point
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; // Your code here

        Transform();
    }

    private void Transform()
    {
        // Get the vertices of the cloned mesh
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            // Your code here
            // Create a new HVector2D from the x and y coordinates of the mesh vertex
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            // Apply the transformation to the vertex using the transform matrix
            vert = transformMatrix * vert;
            // Update the x and y coordinates
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        // Update the vertices of the cloned mesh
        meshManager.clonedMesh.vertices = vertices;
    }
}
