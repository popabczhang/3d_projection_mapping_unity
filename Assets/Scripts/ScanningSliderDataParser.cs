using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanningSliderDataParser : MonoBehaviour {
    
    public string JsonData;
    public Grid grid;

    public UDP_Listener udpListener;
    public bool useUDP = false;
    
    public float sliderValue = 0.5f;
    public Slider uiSlider;

    void Start () {
        
        // if use udp
        if (useUDP)
        {
            if (udpListener._encodedUDP == "")
            {
                Debug.LogWarning("UDP recieved null");
            }
            else
            {
                JsonData = udpListener._encodedUDP;
            }
        }

        // sample data
        // {"grid":[[20, 0], [21, 1], [22, 2], [23, 3], [4, 0], [5, 0], [6, 0], [7, 0], [8, 0], [9, 0], [10, 0], 
        // [11, 0], [12, 0], [13, 0], [14, 0], [15, 0], [16, 0], [17, 0]],"slider":[0.5124]}

        // parsing scanner json text manually
        JsonData = JsonData.Replace(" ", "");
        //Debug.Log(JsonData);
        int i1 = JsonData.IndexOf("{\"grid\":[[");
        int i2 = JsonData.IndexOf("]],");
        string sub = JsonData.Substring(i1 + 10, i2 - (i1 + 10));
        string[] subs = sub.Split(new string[] {"],["}, System.StringSplitOptions.None);
        // generate grid
        grid = new Grid();
        int i = 0;
        foreach (string s in subs)
        {
            string[] sp = s.Split(',');
            Building b = new Building();
            b.type = int.Parse(sp[0]);
            b.rot = int.Parse(sp[1]);
            grid.buildings.Add(b);
            i ++;
        }
        //Debug.Log(grid);
        
        // parsing slider json text manually
        i1 = JsonData.IndexOf("\"slider\":[");
        i2 = JsonData.IndexOf("]}");
        sub = JsonData.Substring(i1 + 10, i2 - (i1 + 10));

        // parse udpData
        sliderValue = float.Parse(sub);

        // update ui slider
        uiSlider.value = sliderValue;
    }

    void Update () {
        if (useUDP)
        {
            if (udpListener._encodedUDP == "")
            {
                Debug.LogWarning("UDP recieved null");
            }
            else
            {
                JsonData = udpListener._encodedUDP;
                
                // sample data
                // {"grid":[[20, 0], [21, 1], [22, 2], [23, 3], [4, 0], [5, 0], [6, 0], [7, 0], [8, 0], [9, 0], [10, 0], 
                // [11, 0], [12, 0], [13, 0], [14, 0], [15, 0], [16, 0], [17, 0]],"slider":[0.5124]}

                // parsing scanner json text manually
                JsonData = JsonData.Replace(" ", "");
                //Debug.Log(JsonData);
                int i1 = JsonData.IndexOf("{\"grid\":[[");
                int i2 = JsonData.IndexOf("]],");
                string sub = JsonData.Substring(i1 + 10, i2 - (i1 + 10));
                string[] subs = sub.Split(new string[] { "],[" }, System.StringSplitOptions.None);
                // generate grid
                grid = new Grid();
                int i = 0;
                foreach (string s in subs)
                {
                    string[] sp = s.Split(',');
                    Building b = new Building();
                    b.type = int.Parse(sp[0]);
                    b.rot = int.Parse(sp[1]);
                    grid.buildings.Add(b);
                    i++;
                }
                //Debug.Log(grid);

                // parsing slider json text manually
                i1 = JsonData.IndexOf("\"slider\":[");
                i2 = JsonData.IndexOf("]}");
                sub = JsonData.Substring(i1 + 10, i2 - (i1 + 10));

                // parse udpData
                sliderValue = float.Parse(sub);

                // update ui slider
                uiSlider.value = sliderValue;
            }
        }
    }

    // for UI debug use udp
    public void ToggleUseUDP(bool toggleValue)
    {
        useUDP = toggleValue;
    }

    public class Grid
    {
        public List<Building> buildings = new List<Building>();
    }

    public class Building
    {
        public int type = -1;
        public int rot = -1;
    }

}
