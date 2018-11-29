using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTextScaleMove : MonoBehaviour {

    public float scaleDelta = 0.2f;
    public ScanningSliderDataParser scanningSliderDataParser;
    public bool isLeft = true;
    public float sliderLength = 1000f;

    private float sliderValue, x, y, z;
    private Vector3 originalScale;
    private float originalPosX, deltaX;

    private void Start()
    {
        originalScale = transform.localScale;
        originalPosX = transform.localPosition.x;
    }

    void Update () {

        sliderValue = scanningSliderDataParser.sliderValue;

        if (isLeft)
        {
            x = originalScale.x + (1f - sliderValue) * scaleDelta;
            y = originalScale.y + (1f - sliderValue) * scaleDelta;
        }
        else
        {
            x = originalScale.x + sliderValue * scaleDelta;
            y = originalScale.y + sliderValue * scaleDelta;
        }

        deltaX = -(0.5f-sliderValue) * sliderLength / 2f;
        transform.localPosition = new Vector3(originalPosX + deltaX, transform.localPosition.y, transform.localPosition.z);

        z = originalScale.z;
        transform.localScale = new Vector3(x, y, z);

    }

}
