using UnityEngine;
using System.Collections;

public class EvandriaUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    

    void DecisionMade (Candidate candidate)
    {
        int changeInMorale = 0;

        //Retrieve decision stats for candidate
        int[] goodArray = new int[5];
        int[] badArray = new int[5];
        
        //5 stats good/bad values placed in array in order

        //Retrieve probability for candidate (e.g: 80/20)
        int goodProbability = 0;
        int badProbability = 0;

        Random rand = new Random();
        int i;
        for (i=0; i<5; i++)
        {
            if(rand.NextDouble() <= badProbability)
            {
                changeInMorale += badArray[i];
            } else
            {
                changeInMorale += goodArray[i];
            }
        }

    }
}
