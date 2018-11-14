using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamControlByUI : MonoBehaviour {

    public GameObject cam;
    public float speedPos;
    public float speedRot;
    public float speedFov;

    public Toggle toggleUI;
    public GameObject camInputMenu;
    public Text textA;
    public Text textB;
    public Text textC;
    public Text textD;
    public Text textE;
    public Text textF;

    void Start () {
        cam = gameObject;

        SaveReset();
        
        // if there's some cam data saved already
        if (PlayerPrefs.GetFloat("camPosX", 9999f) != 9999f)
        {
            Load();
        }
    }

    private void Update()
    {
        if (toggleUI.enabled && camInputMenu.activeInHierarchy)
        {
            textA.text = string.Format("a = {0}", cam.transform.localPosition.x);
            textB.text = string.Format("b = {0}", cam.transform.localPosition.y-0.778f);
            textC.text = string.Format("c = {0}", cam.transform.localPosition.z);
            textD.text = string.Format("d = {0}", (cam.transform.localEulerAngles.x - 90f) * (-1.0f));
            textE.text = string.Format("e = {0}", cam.transform.localEulerAngles.z);
            textF.text = string.Format("f = {0}", cam.GetComponent<Camera>().fieldOfView);
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

    public void InputA(string value)
    {
        float a = float.Parse(value);
        cam.transform.localPosition = new Vector3(a, cam.transform.localPosition.y, cam.transform.localPosition.z);
    }

    public void InputB(string value)
    {
        float b = float.Parse(value);
        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, b+0.778f, cam.transform.localPosition.z);
    }

    public void InputC(string value)
    {
        float c = float.Parse(value);
        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, c);
    }

    public void InputD(string value)
    {
        float d = float.Parse(value);
        cam.transform.localEulerAngles = new Vector3(90f-d, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
    }

    public void InputE(string value)
    {
        float e = float.Parse(value);
        cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, cam.transform.localPosition.y, e);
    }

    public void InputF(string value)
    {
        float f = float.Parse(value);
        cam.GetComponent<Camera>().fieldOfView = f;
    }

}
