using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMorphGO : MonoBehaviour {

    // attach this script to each gameobject that you would like to morph
    // note that it only morph the first mesh component it finds!!!

    public BoxMorphKeyPts boxMorphKeyPts;
    public bool calibrating = false;

    private MeshFilter meshFilter;
    private Mesh mesh;
    private Mesh meshBK;
    private Transform meshTransform;

    void Start() {

        // find first meshfilter component
        Transform[] AllChildren = GetComponentsInChildren<Transform>();
        foreach (Transform Child in AllChildren)
        {
            if (Child.gameObject.GetComponent<MeshFilter>() != null)
            {
                meshFilter = Child.gameObject.GetComponent<MeshFilter>();
                meshTransform = Child;
                break;
            }
        }
        if (meshFilter != null)
        {
            // backup mesh from the meshfilter component
            mesh = meshFilter.mesh;
            meshBK = Instantiate<Mesh>(mesh);
        }
        else
        {
            Debug.LogWarning("BoxMorphGO: no meshfilter found! ");
        }

        // apply box morph once
        ApplyBoxMorph(meshTransform, mesh, meshBK, boxMorphKeyPts);
    }

    // Update is called once per frame
    void Update() {
        // get calibration status from boxMorphKeyPts
        calibrating = boxMorphKeyPts.calibrating;

        // if calibrating, apply box morph once per frame
        if (calibrating)
        {
            ApplyBoxMorph(meshTransform, mesh, meshBK, boxMorphKeyPts);
        }
    }

    // function to apply box morph once
    void ApplyBoxMorph(Transform meshTransform, Mesh mesh, Mesh meshBK, BoxMorphKeyPts boxMorphKeyPts)
    {
        Vector3 a1, b1, d1, e1, a2, b2, c2, d2, e2, f2, g2, h2;
        Vector3 t1, t2;
        float u, v, w;

        a1 = boxMorphKeyPts.a1;
        b1 = boxMorphKeyPts.b1;
        d1 = boxMorphKeyPts.d1;
        e1 = boxMorphKeyPts.e1;

        a2 = boxMorphKeyPts.a2;
        b2 = boxMorphKeyPts.b2;
        c2 = boxMorphKeyPts.c2;
        d2 = boxMorphKeyPts.d2;
        e2 = boxMorphKeyPts.e2;
        f2 = boxMorphKeyPts.f2;
        g2 = boxMorphKeyPts.g2;
        h2 = boxMorphKeyPts.h2;

        // loop all meshes in InputMeshList
        Vector3[] verticesInput = meshBK.vertices;
        Vector3[] verticesOutput = mesh.vertices;
        int i = 0;
        while (i < verticesInput.Length) // loop each vertex
        {

            t1 = meshTransform.TransformPoint(verticesInput[i]);

            u = (t1[0] - a1[0]) / (b1[0] - a1[0]);
            v = (t1[2] - a1[2]) / (d1[2] - a1[2]);
            w = (t1[1] - a1[1]) / (e1[1] - a1[1]);

            t2 = BoxLerp(a2, b2, c2, d2, e2, f2, g2, h2, u, v, w);

            verticesOutput[i] = meshTransform.InverseTransformPoint(t2);

            i++;
        }
        mesh.vertices = verticesOutput;
    }

    // Thanks to Brian-Stone's answer
    // https://forum.unity.com/threads/vector-bilinear-interpolation-of-a-square-grid.205644/

    // Given a (u,v) coordinate that defines a 2D local position inside a planar quadrilateral, find the
    // absolute 3D (x,y,z) coordinate at that location.
    //
    //  0 <----u----> 1
    //  d ----------- c    1
    //  |             |   /|\
    //  |             |    |
    //  |             |    v
    //  |  *(u,v)     |    |
    //  |             |   \|/
    //  a ----------- b    0
    //
    // a, b, c, and d are the vertices of the quadrilateral. They are assumed to exist in the
    // same plane in 3D space, but this function will allow for some non-planar error.
    //
    // Variables u and v are the two-dimensional local coordinates inside the quadrilateral.
    // To find a point that is inside the quadrilateral, both u and v must be between 0 and 1 inclusive.  
    // For example, if you send this function u=0, v=0, then it will return coordinate "a".  
    // Similarly, coordinate u=1, v=1 will return vector "c". Any values between 0 and 1
    // will return a coordinate that is bi-linearly interpolated between the four vertices.


    //public Vector3 QuadLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float u, float v)
    //{
    //    Vector3 abu = Vector3.Lerp(a, b, u);
    //    Vector3 dcu = Vector3.Lerp(d, c, u);
    //    Vector3 t = Vector3.Lerp(abu, dcu, v);
    //    return t;
    //}

    // improved 2D lerp, test point can be outside
    Vector3 QuadLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float u, float v)
    {
        Vector3 abu = (b - a) * u + a;
        Vector3 dcu = (c - d) * u + d;
        Vector3 t = (dcu - abu) * v + abu;
        return t;
    }

    // improved 3D lerp, test point can be outside
    Vector3 BoxLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Vector3 e, Vector3 f, Vector3 g, Vector3 h, float u, float v, float w)
    {
        Vector3 abu = (b - a) * u + a;
        Vector3 dcu = (c - d) * u + d;
        Vector3 t1 = (dcu - abu) * v + abu;
        Vector3 efu = (f - e) * u + e;
        Vector3 hgu = (g - h) * u + h;
        Vector3 t2 = (hgu - efu) * v + efu;
        Vector3 t = (t2 - t1) * w + t1;
        return t;
    }
}