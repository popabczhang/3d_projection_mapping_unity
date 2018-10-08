using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScanning : MonoBehaviour {

    public GameObject webCamGO;
    public GameObject sliderStartPt;
    public GameObject sliderEndPt;
    public GameObject colorRefPtTrue;
    public GameObject[] colorRefPtsFalse;

    public float refCrossSize = 0.05f;
    public int divNum = 100;

    public float sliderValue = 0.0f;

    private WebCamTexture webCamTexture;
    private int webCamPxW;
    private int webCamPxH;

	// Use this for initialization
	void Start () {
        webCamTexture = webCamGO.GetComponent<WebCam>().webcamTexture;
        webCamPxW = webCamTexture.width;
        webCamPxH = webCamTexture.height;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 startPt = sliderStartPt.transform.position;
        Vector3 endPt = sliderEndPt.transform.position;
        Debug.DrawLine(startPt, endPt, Color.magenta);

        List<Vector3> ptsTrue = new List<Vector3>();
        for (int i = 0; i <= divNum; i++)
        {
            Vector3 divPt = startPt + (endPt - startPt) / divNum * i;

            // draw sampled color of divPt in RGB color space
            int x = Mathf.RoundToInt(divPt[0] * (float)webCamPxW);
            int y = Mathf.RoundToInt(divPt[2] * (float)webCamPxH);
            Color sampleColor = webCamTexture.GetPixel(x, y);
            Vector3 samplePt = transform.TransformPoint(new Vector3(sampleColor[0], sampleColor[1], sampleColor[2]));
            Debug.DrawLine(samplePt + new Vector3(-refCrossSize, 0.0f, 0.0f), samplePt + new Vector3(refCrossSize, 0.0f, 0.0f), sampleColor);
            Debug.DrawLine(samplePt + new Vector3(0.0f, -refCrossSize, 0.0f), samplePt + new Vector3(0.0f, refCrossSize, 0.0f), sampleColor);
            Debug.DrawLine(samplePt + new Vector3(0.0f, 0.0f, -refCrossSize), samplePt + new Vector3(0.0f, 0.0f, refCrossSize), sampleColor);

            // check if sample color pt is closer to colorRefPtTrue
            float dTrue = Vector3.Distance(colorRefPtTrue.transform.position, samplePt);
            float dFalse = 9999999f;
            foreach (GameObject colorRefPtFalse in colorRefPtsFalse)
            {
                dFalse = Mathf.Min(dFalse, Vector3.Distance(colorRefPtFalse.transform.position, samplePt));
            }
            Color crossColor = Color.black;
            if (dTrue <= dFalse)
            {
                crossColor = Color.white;
                ptsTrue.Add(divPt);
            }

            // draw divPt on slider
            Debug.DrawLine(divPt + new Vector3(-refCrossSize / 2f, 0.0f, -refCrossSize / 2f), divPt + new Vector3(refCrossSize / 2f, 0.0f, refCrossSize / 2f), crossColor);
            Debug.DrawLine(divPt + new Vector3(-refCrossSize / 2f, 0.0f, refCrossSize / 2f), divPt + new Vector3(refCrossSize / 2f, 0.0f, -refCrossSize / 2f), crossColor);
        }

        // draw average point of all true points and calculate slider value
        Vector3 averagePtTrue = startPt;
        if (ptsTrue.Count > 0)
        {
            averagePtTrue = Vector3.zero;
            for (int i = 0; i < ptsTrue.Count; i++)
            {
                averagePtTrue = averagePtTrue + ptsTrue[i];
            }
            averagePtTrue = averagePtTrue / ptsTrue.Count;
        }
        // draw averagePtTrue on slider
        Debug.DrawLine(averagePtTrue + new Vector3(-refCrossSize * 2f, 0.0f, -refCrossSize * 2f), averagePtTrue + new Vector3(refCrossSize * 2f, 0.0f, refCrossSize * 2f), Color.white);
        Debug.DrawLine(averagePtTrue + new Vector3(-refCrossSize * 2f, 0.0f, refCrossSize * 2f), averagePtTrue + new Vector3(refCrossSize * 2f, 0.0f, -refCrossSize * 2f), Color.white);

        // calculate slider value
        sliderValue = Vector3.Distance(startPt, averagePtTrue) / Vector3.Distance(startPt, endPt);
        Debug.Log(string.Format("Slider 1 Value = {0}. ", sliderValue));
    }
}
