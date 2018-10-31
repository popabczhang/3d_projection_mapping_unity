using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInstantiator : MonoBehaviour {

    public GameObject[] buildingPositions;
    public GameObject[] buildingPrefabsGood;
    public GameObject[] buildingPrefabsBad;
    public ScanningDataParser scanningDataParser;

    public GameObject bldgParent;
    public GameObject[] bldgGOsGood = new GameObject[18];
    public GameObject[] bldgGOsBad = new GameObject[18];

    public int[] prevTypeList = new int[18];
    public int[] prevRotList = new int[18];
    public bool[] changedList = new bool[18];

    void Start () {
        // instantiate buildings
        for (int i = 0; i < scanningDataParser.grid.buildings.Count; i ++)
        {
            //Debug.Log(string.Format("i = {0}", i));
            ScanningDataParser.Building b = scanningDataParser.grid.buildings[i];
            //Debug.Log(string.Format("b = {0}", b));
            if (b.type != -1 && buildingPrefabsGood[b.type] != null)
            {
                //Debug.Log(string.Format("instantiating building {0} in the grid", i));
                bldgGOsGood[i] = Instantiate(buildingPrefabsGood[b.type], buildingPositions[i].transform.position, buildingPositions[i].transform.rotation, bldgParent.transform);
                bldgGOsBad[i] = Instantiate(buildingPrefabsBad[b.type], buildingPositions[i].transform.position, buildingPositions[i].transform.rotation, bldgParent.transform);
            }
        }

        // save prev values for compareson
        prevTypeList = scanningDataParser.grid.typeList;
        prevRotList = scanningDataParser.grid.rotList;
}

    void Update () {
        // compare type and rot list
        for (int i = 0; i < 18; i++)
        {
            if (scanningDataParser.grid.typeList[i] == prevTypeList[i] && scanningDataParser.grid.rotList[i] == prevRotList[i])
            {
                changedList[i] = false;
            }
            else
            {
                changedList[i] = true;
                Debug.Log("changed");
            }
        }


        /*
        // instantiate buildings
        for (int i = 0; i < scanningDataParser.grid.buildings.Count; i++)
        {
            //Debug.Log(string.Format("i = {0}", i));
            ScanningDataParser.Building b = scanningDataParser.grid.buildings[i];
            //Debug.Log(string.Format("b = {0}", b));
            if (b.type != -1 && buildingPrefabsGood[b.type] != null)
            {
                //Debug.Log(string.Format("instantiating building {0} in the grid", i));
                bldgGOsGood[i] = Instantiate(buildingPrefabsGood[b.type], buildingPositions[i].transform.position, buildingPositions[i].transform.rotation, bldgParent.transform);
                bldgGOsBad[i] = Instantiate(buildingPrefabsBad[b.type], buildingPositions[i].transform.position, buildingPositions[i].transform.rotation, bldgParent.transform);
            }
        }
        */


        prevTypeList = scanningDataParser.grid.typeList;
        prevRotList = scanningDataParser.grid.rotList;
    }
}
