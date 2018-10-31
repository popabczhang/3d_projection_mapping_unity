using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScanningDataParser : MonoBehaviour {

    public string ExampleJsonFilePath = "Assets/Resources/Example Building Scanning Data.txt";
    public string JsonData;
    public Grid grid = new Grid();

    void Start () {
        // Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(ExampleJsonFilePath);
        JsonData = reader.ReadToEnd();
        Debug.Log(JsonData);
        reader.Close();

        // parsing json class
        //scannedGrid = JsonUtility.FromJson<Grid>(JsonData); // native jsonUtility doesn't support list of lists
        //Debug.Log(scannedGrid.grid);

        // parsing json text manually
        JsonData = JsonData.Replace(" ", "");
        Debug.Log(JsonData);
        int i1 = JsonData.IndexOf("{\"grid\":[[");
        int i2 = JsonData.IndexOf("]]}");
        string sub = JsonData.Substring(i1 + 10, i2 - (i1 + 10));
        string[] subs = sub.Split(new string[] {"],["}, System.StringSplitOptions.None);
        int i = 0;
        foreach (string s in subs)
        {
            string[] sp = s.Split(',');
            Building b = new Building();
            b.type = int.Parse(sp[0]);
            b.rot = int.Parse(sp[1]);
            grid.buildings.Add(b);
            grid.typeList[i] = b.type;
            grid.rotList[i] = b.rot;
            i ++;
        }
        //Debug.Log(grid);
    }
	
	void Update () {
        // Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(ExampleJsonFilePath);
        JsonData = reader.ReadToEnd();
        //Debug.Log(JsonData);
        reader.Close();

        // parsing json text manually
        JsonData = JsonData.Replace(" ", "");
        //Debug.Log(JsonData);
        int i1 = JsonData.IndexOf("{\"grid\":[[");
        int i2 = JsonData.IndexOf("]]}");
        string sub = JsonData.Substring(i1 + 10, i2 - (i1 + 10));
        string[] subs = sub.Split(new string[] { "],[" }, System.StringSplitOptions.None);
        int i = 0;
        foreach (string s in subs)
        {
            string[] sp = s.Split(',');
            Building b = new Building();
            b.type = int.Parse(sp[0]);
            b.rot = int.Parse(sp[1]);
            grid.buildings.Add(b);
            grid.typeList[i] = b.type;
            grid.rotList[i] = b.rot;
            i++;
        }
    }

    public class Grid
    {
        public List<Building> buildings = new List<Building>();
        public int[] typeList = new int[18];
        public int[] rotList = new int[18];
    }

    public class Building
    {
        public int type = -1;
        public int rot = 0;
    }

}
