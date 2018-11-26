using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadingScript : MonoBehaviour {


    public float scaleDelta = 0.2f;
    public ScanningSliderDataParser scanningSliderDataParser;

    private float sliderValue, x, y, z;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {

        sliderValue = scanningSliderDataParser.sliderValue;

        x = originalScale.x + (1f - sliderValue) * scaleDelta;
        y = originalScale.y;
        z = originalScale.z;
        transform.localScale = new Vector3(x, y, z);

    }
}
