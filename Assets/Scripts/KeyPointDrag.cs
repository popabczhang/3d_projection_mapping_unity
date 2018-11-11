using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPointDrag : MonoBehaviour {

    // ref: https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html

    public Camera cam;
    private Vector3 screenPoint;
    private Vector3 offset;
    private float y;

    //[RequireComponent(typeof(MeshCollider))]
    void OnMouseDown()
    {
        //Debug.Log("OnMouseDown");

        // record y(height) of the gameobject
        y = transform.position.y;

        screenPoint = cam.WorldToScreenPoint(transform.position);
        //Debug.Log(string.Format("screenPoint: {0}.", screenPoint));

        offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        //Debug.Log("OnMouseDrag");

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;

        // apply curPosition and reset y to recorded value
        transform.position = new Vector3(curPosition.x, y, curPosition.z);

    }
}
