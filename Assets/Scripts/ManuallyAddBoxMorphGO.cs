using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuallyAddBoxMorphGO : MonoBehaviour
{

    public BoxMorphKeyPts boxMorphKeyPts;

    // Use this for initialization
    void Start () {
        BoxMorphGO c1 = this.gameObject.AddComponent<BoxMorphGO>();
        c1.boxMorphKeyPts = boxMorphKeyPts;
    }

}
