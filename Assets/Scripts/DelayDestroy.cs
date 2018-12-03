using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour {

    public float delayInSeconds = 4.0f;

	void Start () {
        Destroy(gameObject, delayInSeconds);
    }

}
