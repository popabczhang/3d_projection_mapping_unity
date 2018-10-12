using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFilterShaderUpdate : MonoBehaviour {

    // reference: https://assetstore.unity.com/packages/vfx/shaders/cross-section-66300
    
    public GameObject filterSlider;
    public Vector3 normal;
    public Vector3 position;

    public GameObject inputParentGO;

    private Renderer rend;

    void Start()
    {
        //rend = GetComponent<Renderer>();
        //normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        //position = plane.transform.position;
        //UpdateShaderProperties();
    }
    void Update()
    {
        //UpdateShaderProperties();
    }

    private void UpdateShaderProperties()
    {
        //normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        //position = plane.transform.position;
        //rend.material.SetVector("_PlaneNormal", normal);
        //rend.material.SetVector("_PlanePosition", position);
    }


}
