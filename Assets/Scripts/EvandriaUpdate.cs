using UnityEngine;
using System.Collections;

public class EvandriaUpdate : MonoBehaviour {

    HealthBarScript sliderScript;
    public Candidate chosenCandidate;
    public bool goodOutcome;

    void Start()
    {
        sliderScript = FindObjectOfType<HealthBarScript>();
    }

	
    void DecisionMade (Candidate candidate)
    {
        int changeInMorale = 0;
        chosenCandidate = candidate;

        //Retrieve decision stats for candidate
        //5 stats good/bad values placed in array in order
        int[] goodArray = new int[5]; //Replace with retrieving array from candidate
        int[] badArray = new int[5];
        int bestCase =0;

        foreach (int x in goodArray)
        {
            bestCase += x;
        }
                

        //Retrieve probability for candidate (e.g: 80/20)
        int badProbability = 0;

        
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

        if (bestCase / 2 > changeInMorale)
        {
            goodOutcome = false;
        } else
        {
            goodOutcome = true;
        }


        //Call UpdateSlider on morale slider with input changeInMorale
        sliderScript.UpdateHealth(changeInMorale);

        
    }
}
