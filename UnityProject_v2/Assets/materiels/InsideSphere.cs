using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideSphere : MonoBehaviour
{
    private void Start()
    {
        // Inverser les normales pour rendre la sphère visible de l'intérieur
        var mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i]; // Inverser les normales
        }
        mesh.normals = normals;
    }
}
