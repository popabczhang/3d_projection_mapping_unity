using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInstantiator : MonoBehaviour {

    public GameObject[] buildingPositions;
    public GameObject[] buildingPrefabsGood;
    public GameObject[] buildingPrefabsBad;
    public ScanningDataParser scanningDataParser;

    public GameObject[] bldgGOsGood = new GameObject[18];
    public GameObject[] bldgGOsBad = new GameObject[18];

    void Start () {

        // instantiate buildings
        for (int i = 0; i < scanningDataParser.grid.buildings.Count; i ++)
        {
            ScanningDataParser.Building b = scanningDataParser.grid.buildings[i];
            if (b.type != -1 && buildingPrefabsGood[b.type] != null)
            {
                bldgGOsGood[i] = Instantiate(buildingPrefabsGood[b.type], buildingPositions[i].transform.position, buildingPositions[i].transform.rotation, gameObject.transform);
                bldgGOsBad[i] = Instantiate(buildingPrefabsBad[b.type], buildingPositions[i].transform.position, buildingPositions[i].transform.rotation, gameObject.transform);
            }
        }
	}
	
	void Update () {
		
	}
}
