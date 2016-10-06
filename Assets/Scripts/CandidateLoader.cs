using UnityEngine;
using System.Collections;
using System;

public class CandidateLoader : MonoBehaviour {

    public const string path = "Data";
    private Transform candidateA;
    private Transform candidateB;
    private CandidateAController candidateAController;
    private CandidateBController candidateBController;

    void Start () {
        CandidateContainer ic = CandidateContainer.Load(path);

        foreach (Candidate candidate in ic.candidates) {
            if (candidate.id.Equals("0")) {

                candidateA = transform.Find("First Candidate Profile");

                try {
                    candidateAController = candidateA.GetComponent<CandidateAController>();
                    candidateAController.fullname = candidate.fullname;
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
            else if (candidate.id.Equals("1")) {

                candidateB = transform.Find("Second Candidate Profile");
       
                try {
                    candidateBController = candidateB.GetComponent<CandidateBController>();
                    candidateBController.fullname = candidate.fullname;
                    candidateBController.birthdate = candidate.birthdate;
                    candidateBController.ethnicity = candidate.ethnicity;
                    candidateBController.occupation = candidate.occupation;
                    candidateBController.skills = candidate.skills;
                    candidateBController.description = candidate.description;
                    candidateAController.traits = candidate.traits;
                } catch (NullReferenceException) {
                    print("stupid exception");
                }
                
            }
        }
	}
}
