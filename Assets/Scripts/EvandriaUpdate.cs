using UnityEngine;
using System.Collections;

public class EvandriaUpdate : MonoBehaviour {

    HealthBarScript sliderScript;
    public string chosenCandidate;
    public bool goodOutcome;
    public int changeInMorale;
    public int day;

    public GameObject decisionCanvas;
    public GameObject outcomeCanvas;

    void Start()
    {
        sliderScript = FindObjectOfType<HealthBarScript>();
        day = 1;
    }

	
    public void DecisionMade (string candidateName)
    {
        chosenCandidate = candidateName;

        //Temporarily Hardcoded attributes
        int[] gabrielGoodArray = { 3, 6, 3, 5, 5 };
        int[] gabrielBadArray = { 1, 3, 1, 2, 2 };
        int[] jessicaGoodArray = { -2,-3,-2,5,-3 };
        int[] jessicaBadArray = {-5,-5,-5,2,-5 };

        int[] goodArray; //Replace with retrieving array from candidate
        int[] badArray;

        changeInMorale = 0;

        float badProbability = 0;

        if (candidateName.Equals("Gabriel Johan"))
        {
            badProbability = 0.2f;
            goodArray = gabrielGoodArray;
            badArray = gabrielBadArray;
        } else
        {
            goodArray = jessicaGoodArray;
            badArray = jessicaBadArray;
            badProbability = 0.8f;
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
            

        //Call UpdateSlider on morale slider with input changeInMorale
        sliderScript.UpdateHealth(changeInMorale);

        // TODO if Evadndria health go below 0, Then set day=-1 else day++

        decisionCanvas.SetActive(false);
        outcomeCanvas.SetActive(true);
        FindObjectOfType<OutcomeScript>().PresentOutcome();
        
    }
}
