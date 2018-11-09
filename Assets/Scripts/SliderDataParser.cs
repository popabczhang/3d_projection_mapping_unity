using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDataParser : MonoBehaviour
{

    public string udpData = "0.5";

    public UDP_Listener udpListener;
    public bool useUDP = false;

    public float sliderValue = 0.5f;

    public Slider uiSlider;

    // Use this for initialization
    void Start () {

        // if use udp
        if (useUDP)
        {
            if (udpListener._encodedUDP == "")
            {
                Debug.LogWarning("UDP recieved null");
            }
            else
            {
                udpData = udpListener._encodedUDP;
            }

            // parse udpData
            sliderValue = float.Parse(udpData);

            // update ui slider
            uiSlider.value = sliderValue;
        }

}
	
	// Update is called once per frame
	void Update () {

        // if use udp
        if (useUDP)
        {
            if (udpListener._encodedUDP == "")
            {
                Debug.LogWarning("UDP recieved null");
            }
            else
            {
                udpData = udpListener._encodedUDP;
                
                // parse udpData
                sliderValue = float.Parse(udpData);

                // update ui slider
                uiSlider.value = sliderValue;

            }
        }

    }

    // for UI debug use udp
    public void ToggleUseUDP(bool toggleValue)
    {
        useUDP = toggleValue;
    }
}
