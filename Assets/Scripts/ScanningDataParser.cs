using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScanningDataParser : MonoBehaviour {

    public string ExampleJsonFilePath = "Assets/Resources/Example Building Scanning Data.txt";
    public string JsonData;
    public Grid grid;

    public UDP_Listener udpListener;
    public bool useUDP = false;

    void Start () {
        // Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(ExampleJsonFilePath);
        JsonData = reader.ReadToEnd();
        //Debug.Log(JsonData);
        reader.Close();
        
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

        // parsing json class
        //scannedGrid = JsonUtility.FromJson<Grid>(JsonData); // native jsonUtility doesn't support list of lists
        //Debug.Log(scannedGrid.grid);
        
        // parsing json text manually
        JsonData = JsonData.Replace(" ", "");
        //Debug.Log(JsonData);
        int i1 = JsonData.IndexOf("{\"grid\":[[");
        int i2 = JsonData.IndexOf("]]}");
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

                // parsing json text manually
                JsonData = JsonData.Replace(" ", "");
                //Debug.Log(JsonData);
                int i1 = JsonData.IndexOf("{\"grid\":[[");
                int i2 = JsonData.IndexOf("]]}");
                string sub = JsonData.Substring(i1 + 10, i2 - (i1 + 10));
                string[] subs = sub.Split(new string[] { "],[" }, System.StringSplitOptions.None);
                // regenerate grid
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
            }
        }
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
