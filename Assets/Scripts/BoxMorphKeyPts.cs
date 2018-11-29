using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMorphKeyPts : MonoBehaviour {

    public bool calibrating = false;
    public GameObject keyPts;

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

        // if there's some Box Morph data saved already
        if (PlayerPrefs.GetFloat("a2x", 9999f) != 9999f)
        {
            LoadBoxMorph();
        }

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
        keyPts.SetActive(toggleValue);
    }

    public void SaveBoxMorph()
    {
        PlayerPrefs.SetFloat("a2x", a2.x);
        PlayerPrefs.SetFloat("a2z", a2.z);
        PlayerPrefs.SetFloat("b2x", b2.x);
        PlayerPrefs.SetFloat("b2z", b2.z);
        PlayerPrefs.SetFloat("c2x", c2.x);
        PlayerPrefs.SetFloat("c2z", c2.z);
        PlayerPrefs.SetFloat("d2x", d2.x);
        PlayerPrefs.SetFloat("d2z", d2.z);
        PlayerPrefs.SetFloat("e2x", e2.x);
        PlayerPrefs.SetFloat("e2z", e2.z);
        PlayerPrefs.SetFloat("f2x", f2.x);
        PlayerPrefs.SetFloat("f2z", f2.z);
        PlayerPrefs.SetFloat("g2x", g2.x);
        PlayerPrefs.SetFloat("g2z", g2.z);
        PlayerPrefs.SetFloat("h2x", h2.x);
        PlayerPrefs.SetFloat("h2z", h2.z);
    }

    public void LoadBoxMorph()
    {
        a2 = new Vector3(PlayerPrefs.GetFloat("a2x", a2.x), a2.y, PlayerPrefs.GetFloat("a2z", a2.z));
        b2 = new Vector3(PlayerPrefs.GetFloat("b2x", b2.x), b2.y, PlayerPrefs.GetFloat("b2z", b2.z));
        c2 = new Vector3(PlayerPrefs.GetFloat("c2x", c2.x), c2.y, PlayerPrefs.GetFloat("c2z", c2.z));
        d2 = new Vector3(PlayerPrefs.GetFloat("d2x", d2.x), d2.y, PlayerPrefs.GetFloat("d2z", d2.z));
        e2 = new Vector3(PlayerPrefs.GetFloat("e2x", e2.x), e2.y, PlayerPrefs.GetFloat("e2z", e2.z));
        f2 = new Vector3(PlayerPrefs.GetFloat("f2x", f2.x), f2.y, PlayerPrefs.GetFloat("f2z", f2.z));
        g2 = new Vector3(PlayerPrefs.GetFloat("g2x", g2.x), g2.y, PlayerPrefs.GetFloat("g2z", g2.z));
        h2 = new Vector3(PlayerPrefs.GetFloat("h2x", h2.x), h2.y, PlayerPrefs.GetFloat("h2z", h2.z));

        TargetBoxKeyPts[0].transform.position = a2;
        TargetBoxKeyPts[1].transform.position = b2;
        TargetBoxKeyPts[2].transform.position = c2;
        TargetBoxKeyPts[3].transform.position = d2;
        TargetBoxKeyPts[4].transform.position = e2;
        TargetBoxKeyPts[5].transform.position = f2;
        TargetBoxKeyPts[6].transform.position = g2;
        TargetBoxKeyPts[7].transform.position = h2;
    }

    public void ResetBoxMorph()
    {
        a2 = OriginBoxKeyPts[0].transform.position;
        b2 = OriginBoxKeyPts[1].transform.position;
        c2 = OriginBoxKeyPts[2].transform.position;
        d2 = OriginBoxKeyPts[3].transform.position;
        e2 = OriginBoxKeyPts[4].transform.position;
        f2 = OriginBoxKeyPts[5].transform.position;
        g2 = OriginBoxKeyPts[6].transform.position;
        h2 = OriginBoxKeyPts[7].transform.position;

        TargetBoxKeyPts[0].transform.position = a2;
        TargetBoxKeyPts[1].transform.position = b2;
        TargetBoxKeyPts[2].transform.position = c2;
        TargetBoxKeyPts[3].transform.position = d2;
        TargetBoxKeyPts[4].transform.position = e2;
        TargetBoxKeyPts[5].transform.position = f2;
        TargetBoxKeyPts[6].transform.position = g2;
        TargetBoxKeyPts[7].transform.position = h2;
    }


}