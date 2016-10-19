using UnityEngine;
using System.Collections;
using System;

public class CandidateLoader : MonoBehaviour {

    public const string path = "Data";
    private int randCandidateA;
    private string randAMoral;
    private int randCandidateB;
    public static int[] availableCandidates = { 0, 1, 2, 3, 4 };
    private Transform candidateA;
    private Transform candidateB;
    private CandidateAController candidateAController;
    private CandidateBController candidateBController;
    private CandidateContainer ic;

    void Start () {
        
        ic = CandidateContainer.Load(path);

        while (true) {
            randCandidateA = findValidCandidate("A");
            if (randCandidateA != -1)
            {
                availableCandidates[randCandidateA] = -1;
                randAMoral = ic.candidates[randCandidateA].moral;
                break;
            }
        }
        while (true)
        {
            randCandidateB = findValidCandidate("B");
            if (randCandidateB != -1)
            {
                availableCandidates[randCandidateB] = -1;
                break;
            }
        }

        GameObject player = GameObject.Find("Player");
        
        CandidateAssociations cAssociations = FindObjectOfType<CandidateAssociations>();
        Vector3[] townSpawn = { new Vector3(-105.9f, -220.2f, 0), new Vector3(-109, -194.4f, 0), new Vector3(-102.8f, -162.2f, 0), new Vector3(-90, -194, 0), new Vector3(-77.2f, -210, 0), new Vector3(-70.6f, -191, 0), new Vector3(-61.5f, -200.5f, 0), new Vector3(-48.2f, -162, 0), new Vector3(-32, -213, 0), new Vector3(-23, -181.2f, 0), new Vector3(-19.7f, -162.4f, 0) };
        cAssociations.locations.Add(new Locations.Location(new Vector3(-48, -220, 0), "Town Square", townSpawn));

        foreach (CandidateXML candidate in ic.candidates) {
            if (candidate.id.Equals(randCandidateA.ToString())) {

                candidateA = transform.Find("First Candidate Profile");

                try {
                    candidateAController = candidateA.GetComponent<CandidateAController>();
                    candidateAController.fullname = candidate.fullname;
                    cAssociations.CandidateAName = candidate.fullname.Split(' ')[0];
                    candidateAController.moral = candidate.moral;
                    candidateAController.goodArray = candidate.goodArray;
                    candidateAController.badArray = candidate.badArray;
                    candidateAController.houseSize = candidate.houseSize;
                    Locations locations = player.GetComponent<Locations>();
                    for (int i = 0; i < locations.locations.Count; i++)
                    {
                        Locations.Location loco = (Locations.Location)locations.locations[i];
                        if (candidateAController.houseSize.Equals(loco.size))
                        {
                            cAssociations.houseA = loco;
                            cAssociations.locations.Add(loco);
                            locations.locations.RemoveAt(i);
                            break;
                        }
                    }
                    cAssociations.npcNameA = candidate.npcName;
                    cAssociations.itemNamesA.Add(candidate.itemName1);
                    cAssociations.itemNamesA.Add(candidate.itemName2);
                    candidateAController.birthdate = candidate.birthdate;
                    candidateAController.ethnicity = candidate.ethnicity;
                    candidateAController.occupation = candidate.occupation;
                    candidateAController.skills = candidate.skills;
                    candidateAController.description = candidate.description;
                    candidateAController.traits = candidate.traits;
                } catch (NullReferenceException) {
                    print("stupid exception");
                }
            }
            else if (candidate.id.Equals(randCandidateB.ToString())) {

                candidateB = transform.Find("Second Candidate Profile");
       
                try {
                    candidateBController = candidateB.GetComponent<CandidateBController>();
                    candidateBController.fullname = candidate.fullname;
                    cAssociations.CandidateBName = candidate.fullname.Split(' ')[0];
                    candidateBController.moral = candidate.moral;
                    candidateBController.goodArray = candidate.goodArray;
                    candidateBController.badArray = candidate.badArray;
                    candidateBController.houseSize = candidate.houseSize;
                    Locations locations = player.GetComponent<Locations>();
                    for (int i = 0; i < locations.locations.Count; i++)
                    {
                        Locations.Location loco = (Locations.Location) locations.locations[i];
                        if (candidateBController.houseSize.Equals(loco.size))
                        {
                            cAssociations.houseB = loco;
                            cAssociations.locations.Add(loco);
                            locations.locations.RemoveAt(i);
                            break;
                        }
                    }
                    cAssociations.npcNameB = candidate.npcName;
                    cAssociations.itemNamesB.Add(candidate.itemName1);
                    cAssociations.itemNamesB.Add(candidate.itemName2);
                    candidateBController.birthdate = candidate.birthdate;
                    candidateBController.ethnicity = candidate.ethnicity;
                    candidateBController.occupation = candidate.occupation;
                    candidateBController.skills = candidate.skills;
                    candidateBController.description = candidate.description;
                    candidateBController.traits = candidate.traits;
                } catch (NullReferenceException) {
                    print("stupid exception");
                }
                
            }
        }
	}

    public int findValidCandidate(string candIndex)
    {
        int randNumber = UnityEngine.Random.Range(0, 5);
        if (candIndex.Equals("A")){
            if (availableCandidates[randNumber] != -1) {
                return randNumber;
            }
            else {
                return -1;
            }
        }
        else
        {
            if (availableCandidates[randNumber] != -1)
            {
                string randMoral = ic.candidates[randNumber].moral;
                if (randMoral.Equals(randAMoral) && !(randAMoral.Equals("Neutral")))
                {
                    return -1;
                }
                else
                {
                    return randNumber;
                }
            }
            else
            {
                return -1;
            }
        } 
    }
}
