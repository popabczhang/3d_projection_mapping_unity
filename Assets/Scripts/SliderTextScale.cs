using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTextScale : MonoBehaviour {

    public float scaleDelta = 0.2f;
    public ScanningSliderDataParser scanningSliderDataParser;
    public bool isLeft = true;

    private float sliderValue, x, y, z;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
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

        z = originalScale.z;
        transform.localScale = new Vector3(x, y, z);

    }

}
