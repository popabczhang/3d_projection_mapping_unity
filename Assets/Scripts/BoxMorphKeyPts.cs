using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMorphKeyPts : MonoBehaviour {

    public bool calibrating = false;

    public GameObject[] OriginBoxKeyPts;
    public GameObject[] TargetBoxKeyPts;
    public Vector3 a1, b1, c1, d1, e1, f1, g1, h1, a2, b2, c2, d2, e2, f2, g2, h2;

    // Use this for initialization
    void Start () {

        a1 = OriginBoxKeyPts[0].transform.position;
        b1 = OriginBoxKeyPts[1].transform.position;
        c1 = OriginBoxKeyPts[2].transform.position;
        d1 = OriginBoxKeyPts[3].transform.position;
        e1 = OriginBoxKeyPts[4].transform.position;
        f1 = OriginBoxKeyPts[5].transform.position;
        g1 = OriginBoxKeyPts[6].transform.position;
        h1 = OriginBoxKeyPts[7].transform.position;

        a2 = TargetBoxKeyPts[0].transform.position;
        b2 = TargetBoxKeyPts[1].transform.position;
        c2 = TargetBoxKeyPts[2].transform.position;
        d2 = TargetBoxKeyPts[3].transform.position;
        e2 = TargetBoxKeyPts[4].transform.position;
        f2 = TargetBoxKeyPts[5].transform.position;
        g2 = TargetBoxKeyPts[6].transform.position;
        h2 = TargetBoxKeyPts[7].transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        if (calibrating)
        {

            a1 = OriginBoxKeyPts[0].transform.position;
            b1 = OriginBoxKeyPts[1].transform.position;
            c1 = OriginBoxKeyPts[2].transform.position;
            d1 = OriginBoxKeyPts[3].transform.position;
            e1 = OriginBoxKeyPts[4].transform.position;
            f1 = OriginBoxKeyPts[5].transform.position;
            g1 = OriginBoxKeyPts[6].transform.position;
            h1 = OriginBoxKeyPts[7].transform.position;

            a2 = TargetBoxKeyPts[0].transform.position;
            b2 = TargetBoxKeyPts[1].transform.position;
            c2 = TargetBoxKeyPts[2].transform.position;
            d2 = TargetBoxKeyPts[3].transform.position;
            e2 = TargetBoxKeyPts[4].transform.position;
            f2 = TargetBoxKeyPts[5].transform.position;
            g2 = TargetBoxKeyPts[6].transform.position;
            h2 = TargetBoxKeyPts[7].transform.position;

        }
		
	}

    public void ToggleCalibration(bool toggleValue)
    {
        calibrating = toggleValue;
        this.gameObject.SetActive(toggleValue);
    }
}
