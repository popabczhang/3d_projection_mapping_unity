using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour {

    public GameObject webCamCanvasGO;
    public WebCamTexture webcamTexture;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        Renderer renderer = webCamCanvasGO.GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
