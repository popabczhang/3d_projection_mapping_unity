using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderCalibration : MonoBehaviour {

    public GameObject sliderTexts;
    public GameObject indicator;
    public MouseDrag mouseDrag;
    public float originalZ;
    public bool calibrating = false;

    // Use this for initialization
    void Start ()
    {

        originalZ = sliderTexts.transform.position.z;
        
        // if there's slider calibration data saved already
        //Debug.Log("sliderTextZ");
        if (PlayerPrefs.GetFloat("sliderTextZ", 9999f) != 9999f)
        {
            LoadSliderCalibration();
        }

    }

    public void ToggleCalibration(bool toggleValue)
    {
        calibrating = toggleValue;
        indicator.SetActive(toggleValue);
        mouseDrag.enableZ = toggleValue;
    }

    public void SaveSliderCalibration()
    {
        PlayerPrefs.SetFloat("sliderTextZ", sliderTexts.transform.position.z);
    }

    public void LoadSliderCalibration()
    {
        sliderTexts.transform.position = new Vector3(sliderTexts.transform.position.x, sliderTexts.transform.position.y, PlayerPrefs.GetFloat("sliderTextZ", sliderTexts.transform.position.z));
    }

    public void ResetSliderCalibration()
    {
        sliderTexts.transform.position = new Vector3(sliderTexts.transform.position.x, sliderTexts.transform.position.y, originalZ);
    }
}
