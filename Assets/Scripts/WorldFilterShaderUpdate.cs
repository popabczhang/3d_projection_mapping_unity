using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFilterShaderUpdate : MonoBehaviour {

    // reference: https://assetstore.unity.com/packages/vfx/shaders/cross-section-66300
    
    public GameObject filterSlider;
    public GameObject inputParentGO;
    public BoxMorphKeyPts boxMorphKeyPts;
    public ScanningSliderDataParser scanningSliderDataParser;

    public float speed = 0.2f;

    public bool auto = true;
    public float xLeft = 0.37f;
    public float xRight = 1.53f;

    public float sliderExtendRatio = 1.1429f; // extend ratio = length of bounding box of all roads / length of bounding box of all buildings
    public float sliderStartOffset = 0.0f;
    public float sliderEndOffset = 0.0f;

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
            Vector3 position = boxMorphKeyPts.TargetBoxKeyPts[0].transform.position * (1.0f - scanningSliderDataParser.sliderValue) + boxMorphKeyPts.TargetBoxKeyPts[1].transform.position * scanningSliderDataParser.sliderValue;
            GameObject meshGO = inputGOList[i];
            GameObject meshParentGO = meshGO.transform.parent.parent.gameObject;
            string meshParentGOName = meshParentGO.name;
            //Debug.Log(string.Format("meshParentGOName = {0}", meshParentGOName));
            string nameSuffix = meshParentGOName.Substring(meshParentGOName.Length - 4 - 7, 4); // name has "(Clone)" at the end
            //Debug.Log(string.Format("nameSuffix = {0}", nameSuffix));
            Vector3 pt0 = position;
            Vector3 pt1 = boxMorphKeyPts.TargetBoxKeyPts[3].transform.position * (1.0f - scanningSliderDataParser.sliderValue) + boxMorphKeyPts.TargetBoxKeyPts[2].transform.position * scanningSliderDataParser.sliderValue;
            Vector3 pt4 = boxMorphKeyPts.TargetBoxKeyPts[4].transform.position * (1.0f - scanningSliderDataParser.sliderValue) + boxMorphKeyPts.TargetBoxKeyPts[5].transform.position * scanningSliderDataParser.sliderValue;
            Vector3 pt5 = boxMorphKeyPts.TargetBoxKeyPts[7].transform.position * (1.0f - scanningSliderDataParser.sliderValue) + boxMorphKeyPts.TargetBoxKeyPts[6].transform.position * scanningSliderDataParser.sliderValue;
            Vector3 pt2 = (pt4 + pt5) / 2f;
            Vector3 normal = new Vector3(1f, 1f, 1f);
            if (nameSuffix == "good")
            {
                //Debug.Log("nameSuffix != \"good\"");
                normal = Vector3.Normalize(Vector3.Cross(pt1 - pt0, pt2 - pt0)) * -1f;
            }
            else
            {
                //Debug.Log("nameSuffix == \"good\"");
                normal = Vector3.Normalize(Vector3.Cross(pt1 - pt0, pt2 - pt0));
            }
            //Debug.Log(string.Format("normal = {0}", normal));

            // extend slider x, from boundary of building to boundary of road
            float sliderExtendCenterX = (boxMorphKeyPts.OriginBoxKeyPts[0].transform.position.x + boxMorphKeyPts.OriginBoxKeyPts[1].transform.position.x) / 2f;
            position = new Vector3((position.x - sliderExtendCenterX) * sliderExtendRatio + sliderExtendCenterX, position.y, position.z);
            normal = new Vector3(normal.x * sliderExtendRatio, normal.y, normal.z);

            // update shader
            rend.material.SetVector("_FilterPosition", position);
            rend.material.SetVector("_FilterNormal", normal);
        }
    }

    public void SetFilterPosition(float sliderValue)
    {
        auto = false;
        float x = xLeft + (xRight - xLeft) * sliderValue;
        float y = filterSlider.transform.position.y;
        float z = filterSlider.transform.position.z;
        filterSlider.transform.SetPositionAndRotation(new Vector3(x, y, z), filterSlider.transform.rotation);
        scanningSliderDataParser.sliderValue = sliderValue;
    }

    public void AutoFilterPosition(bool setAuto)
    {
        auto = true;
    }

}
