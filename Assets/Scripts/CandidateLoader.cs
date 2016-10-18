using UnityEngine;
using System.Collections;
using System;

public class CandidateLoader : MonoBehaviour {

    public const string path = "Data";
    private int randCandidateA;
    private string randAMoral;
    private int randCandidateB;
    public static int[] availableCandidates = { 0, 1, 2 };
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
                break;
            }
        }

        foreach (CandidateXML candidate in ic.candidates) {
            if (candidate.id.Equals(randCandidateA.ToString())) {

                candidateA = transform.Find("First Candidate Profile");

                try {
                    candidateAController = candidateA.GetComponent<CandidateAController>();
                    candidateAController.fullname = candidate.fullname;
                    candidateAController.moral = candidate.moral;
                    candidateAController.goodArray = candidate.goodArray;
                    candidateAController.badArray = candidate.badArray;
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
                    candidateBController.moral = candidate.moral;
                    candidateBController.goodArray = candidate.goodArray;
                    candidateBController.badArray = candidate.badArray;
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
        int randNumber = UnityEngine.Random.Range(0, 3);
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
