using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayActivate : MonoBehaviour {

    public float delayPerGOinSec = 3.0f;
    public GameObject[] GOtoDelay;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < GOtoDelay.Length;i++){
            GOtoDelay[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time < GOtoDelay.Length*delayPerGOinSec) {
            for (int i = 0; i < GOtoDelay.Length; i++)
            {
                if (Time.time > i * delayPerGOinSec)
                {
                    GOtoDelay[i].SetActive(true);

                }
            }
        }
    }
}
