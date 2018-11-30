using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuallyAddBoxMorphGO : MonoBehaviour
{

    public BoxMorphKeyPts boxMorphKeyPts;

    private BoxMorphGO boxMorphGO;

    // Use this for initialization
    void Start () {

        // find all meshfilter component
        Transform[] AllChildren = GetComponentsInChildren<Transform>();
        foreach (Transform Child in AllChildren)
        {
            if (Child.gameObject.GetComponent<MeshFilter>() != null)
            {
                boxMorphGO = Child.gameObject.AddComponent<BoxMorphGO>();
                boxMorphGO.boxMorphKeyPts = boxMorphKeyPts;
            }
        }

    }

}
