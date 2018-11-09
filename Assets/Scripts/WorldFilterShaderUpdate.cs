using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFilterShaderUpdate : MonoBehaviour {

    // reference: https://assetstore.unity.com/packages/vfx/shaders/cross-section-66300
    
    public GameObject filterSlider;
    public GameObject inputParentGO;

    public float speed = 0.2f;

    public bool auto = true;
    public float xLeft = 0.37f;
    public float xRight = 1.53f;

    void Update()
    {
        // auto moving mode for filter
        if (auto)
        {
            if (filterSlider.transform.position[0] < xLeft)
            {
                speed = Mathf.Abs(speed);
            }
            else if (filterSlider.transform.position[0] > xRight)
            {
                speed = -Mathf.Abs(speed);
            }
            filterSlider.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }


        // Update all gameobject's shader property

        // find all GO in inputParentGO and add to inputGOList
        List<GameObject> inputGOList = new List<GameObject>();
        Transform[] AllChildren = inputParentGO.GetComponentsInChildren<Transform>();
        foreach (Transform Child in AllChildren)
        {
            if (Child.gameObject.GetComponent<Renderer>() != null)
            {
                inputGOList.Add(Child.gameObject);
            }
        }

        // loop all GO in inputGOList
        for (int i = 0; i < inputGOList.Count; i++)
        {
            Renderer rend = inputGOList[i].GetComponent<Renderer>();
            Vector3 position = filterSlider.transform.position;
            rend.material.SetVector("_FilterPosition", position);
        }
    }

    public void SetFilterPosition(float sliderValue)
    {
        auto = false;
        float x = xLeft + (xRight - xLeft) * sliderValue;
        float y = filterSlider.transform.position.y;
        float z = filterSlider.transform.position.z;
        filterSlider.transform.SetPositionAndRotation(new Vector3(x, y, z), filterSlider.transform.rotation);
    }

    public void AutoFilterPosition(bool setAuto)
    {
        auto = true;
    }

}
