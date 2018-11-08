using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWaveEffects : MonoBehaviour {

    public GameObject building;
    public float interval;
    public GameObject waveEffect;
    public float speed;

    private GameObject myWaveEffect;
    private float x;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(building, new Vector3(i*interval, 0, j* interval), transform.rotation, transform);
            }
        }

        myWaveEffect = Instantiate(waveEffect, transform);
        x = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        x = myWaveEffect.transform.position.x;

        if (x > 10.0f)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (x < -10.0f)
        {
            speed = Mathf.Abs(speed);
        }

        myWaveEffect.transform.position = new Vector3(x + speed, 0.0f, 0.0f);

    }
}
