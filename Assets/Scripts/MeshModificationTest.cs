using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshModificationTest : MonoBehaviour {

    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < vertices.Length) // loop each vertex
        {
            vertices[i] += normals[i] * Mathf.Sin(Time.time) * 0.001f;    // a loop animation
            float s = 0.001f;
            vertices[i] += new Vector3(Random.Range(-s, s), Random.Range(-s, s), Random.Range(-s, s));  // add random noise
            i++;
        }
        mesh.vertices = vertices;
    }
}