using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFilterShaderUpdate : MonoBehaviour {

    // reference: https://assetstore.unity.com/packages/vfx/shaders/cross-section-66300
    
    public GameObject filterSlider;
    public GameObject inputParentGO;

    public float speed = 0.2f;

    void Update()
    {
        if (filterSlider.transform.position[0] < 0.2f)
        {
            speed = Mathf.Abs(speed);
        }
        else if (filterSlider.transform.position[0] > 1.7f)
        {
            speed = -Mathf.Abs(speed);
        }
        filterSlider.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);



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

}
