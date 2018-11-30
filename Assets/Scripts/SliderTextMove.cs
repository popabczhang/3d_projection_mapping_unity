using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTextMove : MonoBehaviour {
    
    public ScanningSliderDataParser scanningSliderDataParser;
    public float sliderLength = 1f;

    private float sliderValue;
    private float originalPosX, deltaX;

    private void Start()
    {
        originalPosX = transform.localPosition.x;
    }

    void Update () {

        sliderValue = scanningSliderDataParser.sliderValue;

        deltaX = -(0.5f-sliderValue) * sliderLength / 2f;
        transform.localPosition = new Vector3(originalPosX + deltaX, transform.localPosition.y, transform.localPosition.z);

    }

}
