using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToggleActive : MonoBehaviour {

    public GameObject targetGO;
    public string keyLetter = "u";
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(keyLetter))
        {
            targetGO.SetActive(!targetGO.activeInHierarchy);
        }

    }


}
