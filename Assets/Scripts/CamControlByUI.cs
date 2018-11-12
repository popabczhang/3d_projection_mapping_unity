using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControlByUI : MonoBehaviour {

    public GameObject cam;
    public float speedPos;
    public float speedRot;
    public float speedFov;

	void Start () {
        cam = gameObject;

        SaveReset();
        
        // if there's some cam data saved already
        if (PlayerPrefs.GetFloat("camPosX", 9999f) != 9999f)
        {
            Load();
        }
    }

    public void CamLeft()
    {
        cam.transform.Translate(new Vector3(-speedPos, 0f, 0f), Space.Self);
    }

    public void CamRight()
    {
        cam.transform.Translate(new Vector3(speedPos, 0f, 0f), Space.Self);
    }

    public void CamUp()
    {
        cam.transform.Translate(new Vector3(0f, speedPos, 0f), Space.Self);
    }

    public void CamDown()
    {
        cam.transform.Translate(new Vector3(0f, -speedPos, 0f), Space.Self);
    }

    public void CamBackward()
    {
        cam.transform.Translate(new Vector3(0f, 0f, -speedPos), Space.Self);
    }

    public void CamForward()
    {
        cam.transform.Translate(new Vector3(0f, 0f, speedPos), Space.Self);
    }

    public void CamCW()
    {
        cam.transform.Rotate(cam.transform.up, speedRot, Space.Self);
    }

    public void CamCCW()
    {
        cam.transform.Rotate(cam.transform.up, -speedRot, Space.Self);
    }

    public void CamNodUp()
    {
        cam.transform.Rotate(cam.transform.right, -speedRot, Space.Self);
    }

    public void CamNodDown()
    {
        cam.transform.Rotate(cam.transform.right, speedRot, Space.Self);
    }

    public void CamNarrow()
    {
        float fov = cam.GetComponent<Camera>().fieldOfView;
        cam.GetComponent<Camera>().fieldOfView = fov - speedFov;
    }

    public void CamWide()
    {
        float fov = cam.GetComponent<Camera>().fieldOfView;
        cam.GetComponent<Camera>().fieldOfView = fov + speedFov;
    }

    public void CamSpeedUp()
    {
        speedPos = speedPos * 2.0f;
        speedRot = speedRot * 2.0f;
        speedFov = speedFov * 2.0f;
    }

    public void CamSpeedDown()
    {
        speedPos = speedPos / 2.0f;
        speedRot = speedRot / 2.0f;
        speedFov = speedFov / 2.0f;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("camPosX", cam.transform.localPosition.x);
        PlayerPrefs.SetFloat("camPosY", cam.transform.localPosition.y);
        PlayerPrefs.SetFloat("camPosZ", cam.transform.localPosition.z);
        PlayerPrefs.SetFloat("camRotX", cam.transform.localEulerAngles.x);
        PlayerPrefs.SetFloat("camRotY", cam.transform.localEulerAngles.y);
        PlayerPrefs.SetFloat("camRotZ", cam.transform.localEulerAngles.z);
        PlayerPrefs.SetFloat("camFov", cam.GetComponent<Camera>().fieldOfView);
    }

    public void Load()
    {
        float px = PlayerPrefs.GetFloat("camPosX", cam.transform.localPosition.x);
        float py = PlayerPrefs.GetFloat("camPosY", cam.transform.localPosition.y);
        float pz = PlayerPrefs.GetFloat("camPosZ", cam.transform.localPosition.z);
        cam.transform.localPosition = new Vector3(px, py, pz);
        float rx = PlayerPrefs.GetFloat("camRotX", cam.transform.localEulerAngles.x);
        float ry = PlayerPrefs.GetFloat("camRotY", cam.transform.localEulerAngles.y);
        float rz = PlayerPrefs.GetFloat("camRotZ", cam.transform.localEulerAngles.z);
        cam.transform.localEulerAngles = new Vector3(rx, ry, rz);
        float fov = PlayerPrefs.GetFloat("camFov", cam.GetComponent<Camera>().fieldOfView);
        cam.GetComponent<Camera>().fieldOfView = fov;
    }

    public void SaveReset()
    {
        PlayerPrefs.SetFloat("camResetPosX", cam.transform.localPosition.x);
        PlayerPrefs.SetFloat("camResetPosY", cam.transform.localPosition.y);
        PlayerPrefs.SetFloat("camResetPosZ", cam.transform.localPosition.z);
        PlayerPrefs.SetFloat("camResetRotX", cam.transform.localEulerAngles.x);
        PlayerPrefs.SetFloat("camResetRotY", cam.transform.localEulerAngles.y);
        PlayerPrefs.SetFloat("camResetRotZ", cam.transform.localEulerAngles.z);
        PlayerPrefs.SetFloat("camResetFov", cam.GetComponent<Camera>().fieldOfView);
    }

    public void LoadReset()
    {
        float px = PlayerPrefs.GetFloat("camResetPosX", cam.transform.localPosition.x);
        float py = PlayerPrefs.GetFloat("camResetPosY", cam.transform.localPosition.y);
        float pz = PlayerPrefs.GetFloat("camResetPosZ", cam.transform.localPosition.z);
        cam.transform.localPosition = new Vector3(px, py, pz);
        float rx = PlayerPrefs.GetFloat("camResetRotX", cam.transform.localEulerAngles.x);
        float ry = PlayerPrefs.GetFloat("camResetRotY", cam.transform.localEulerAngles.y);
        float rz = PlayerPrefs.GetFloat("camResetRotZ", cam.transform.localEulerAngles.z);
        cam.transform.localEulerAngles = new Vector3(rx, ry, rz);
        float fov = PlayerPrefs.GetFloat("camResetFov", cam.GetComponent<Camera>().fieldOfView);
        cam.GetComponent<Camera>().fieldOfView = fov;
    }

}
