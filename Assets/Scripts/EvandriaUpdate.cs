﻿using UnityEngine;
using System.Collections;

public class EvandriaUpdate : MonoBehaviour {

    HealthBarScript sliderScript;
    public static int level = 1;
    public static int score = 0;
    public int level1;
    public int score1;
    public string chosenCandidate;
    public string chosenCandidateName;
    public string rejectCandidateName;
    public bool goodOutcome;
    public int changeInMorale;
    float badProbability;
    CandidateAController firstCandidate;
    CandidateBController secondCandidate;

    public GameObject decisionCanvas;
    public GameObject outcomeCanvas;

    void Start()
    {
        sliderScript = FindObjectOfType<HealthBarScript>();
        level1 = level;
        score1 = score;
    }

	
    public void DecisionMade (string candidate, string chosenName, string rejectName)
    {
        chosenCandidate = candidate;
        chosenCandidateName = chosenName;
        rejectCandidateName = rejectName;

        int[] goodArray; //Replace with retrieving array from candidate
        int[] badArray;

        changeInMorale = 0;

        badProbability = 0;

        if (candidate.Equals("first"))
        {
            firstCandidate = FindObjectOfType<CandidateAController>();
            Probability(firstCandidate.moral);
            goodArray = stringToArray(firstCandidate.goodArray);
            badArray = stringToArray(firstCandidate.badArray);
        } else
        {
            secondCandidate = FindObjectOfType<CandidateBController>();
            Probability(secondCandidate.moral);
            goodArray = stringToArray(secondCandidate.goodArray);
            badArray = stringToArray(secondCandidate.badArray);
        }

        //Retrieve decision stats for candidate
        //5 stats good/bad values placed in array in order

        int bestCase =0;

        foreach (int x in goodArray)
        {
            bestCase += x;
        }


        //Retrieve probability for candidate (e.g: 80/20)
        int i;
        for (i=0; i<5; i++)
        {
            if( Random.Range(0f,1f) <= badProbability)
            {
                changeInMorale += badArray[i];
            } else
            {
                changeInMorale += goodArray[i];
            }
        }
        if (bestCase >= 0)
        {
            if (bestCase / 2 > changeInMorale)
            {
                goodOutcome = false;
            }
            else
            {
                goodOutcome = true;
            }
        }
        else {
            if (bestCase * 2 > changeInMorale)
            {
                goodOutcome = false;
            }
            else
            {
                goodOutcome = true;
            }
        }
        
        // Call UpdateSlider on morale slider with input changeInMorale
        // If health goes below 20, then no next level. They will be taken to game over screen.
        sliderScript.UpdateHealth(changeInMorale);
        // TODO if Evadndria health go below 0, Then set day=-1 else day++

        decisionCanvas.SetActive(false);
        outcomeCanvas.SetActive(true);
        FindObjectOfType<OutcomeScript>().PresentOutcome();
        
    }

    public void Probability(string moralProbability)
    {
        if (moralProbability.Equals("Good"))
        {
            badProbability = 0.2f;
        }
        else if (moralProbability.Equals("Bad"))
        {
            badProbability = 0.8f;
        }
        else
        {
            badProbability = 0.5f;
        }
    }

    public int[] stringToArray(string array)
    {
        int[] intArray = { 0, 0, 0, 0, 0 };
        string[] splitArray = array.Split(',');
        for (int i = 0; i < splitArray.Length; i++)
        {
            intArray[i] = int.Parse(splitArray[i]);
        }

        return intArray;
    }
}
