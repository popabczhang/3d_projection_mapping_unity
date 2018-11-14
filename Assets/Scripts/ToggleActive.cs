using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour {
    
	public void ToggleActiveByButton () {
        gameObject.SetActive(!gameObject.activeInHierarchy);
	}

}
