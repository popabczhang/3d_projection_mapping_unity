using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour {

    public Text textFPS;

    void Start()
    {
        textFPS = GetComponent<Text>();
    }

    void Update ()
    {
        if (Time.frameCount % 10 == 0)
        {
            textFPS.text = string.Format("{0} fps", (int)(1.0f / Time.deltaTime));
        }
	}
}
