using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CandidateAssociations : MonoBehaviour {


    public ArrayList locations;

    public string CandidateAName;
    public List<string> itemNamesA;
    public string npcNameA;
    public Locations.Location houseA;


    public string CandidateBName;
    public List<string> itemNamesB;
    public string npcNameB;
    public Locations.Location houseB;

    void Start()
    {
        Vector3[] officeSpawn = { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
        locations = new ArrayList();
        locations.Add(new Locations.Location(new Vector3(-13, -5, 0), "Office", officeSpawn));
    }

}
