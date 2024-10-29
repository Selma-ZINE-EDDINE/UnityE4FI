using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class InvertNormals : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;

        // Inverser les normales
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }
        mesh.normals = normals;

        // Inverser l'ordre des triangles
        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] triangles = mesh.GetTriangles(i);
            for (int j = 0; j < triangles.Length; j += 3)
            {
                // Swap triangles (inverser les triangles)
                int temp = triangles[j];
                triangles[j] = triangles[j + 1];
                triangles[j + 1] = temp;
            }
            mesh.SetTriangles(triangles, i);
        }
    }
}
