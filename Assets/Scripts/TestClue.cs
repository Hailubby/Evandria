using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestClue : MonoBehaviour {

    private ArrayList firstCandidateClues = new ArrayList();
    private ArrayList secondCandidateClues = new ArrayList();

    public void populateClues()
    {
        firstCandidateClues.Add("First Clue for First Candidate");
        firstCandidateClues.Add("Second Clue");

        secondCandidateClues.Add("First Clue for Second Candidate");

        for (int i = 0; i < firstCandidateClues.Count; i++){
            switch (i)
            {
                case 0:
                    Text firstClue = GameObject.Find("First Clue 1").GetComponent<Text>();
                    firstClue.text = (string)firstCandidateClues[i];
                    break;
                case 1:
                    Text secondClue = GameObject.Find("First Clue 2").GetComponent<Text>();
                    secondClue.text = (string)firstCandidateClues[i];
                    break;
                case 2:
                    Text thirdClue = GameObject.Find("First Clue 3").GetComponent<Text>();
                    thirdClue.text = (string)firstCandidateClues[i];
                    break;
            }
        }

        for (int j = 0; j < secondCandidateClues.Count; j++)
        {
            switch (j)
            {
                case 0:
                    Text firstClue = GameObject.Find("Second Clue 1").GetComponent<Text>();
                    firstClue.text = (string)firstCandidateClues[j];
                    break;
                case 1:
                    Text secondClue = GameObject.Find("Second Clue 2").GetComponent<Text>();
                    secondClue.text = (string)firstCandidateClues[j];
                    break;
                case 2:
                    Text thirdClue = GameObject.Find("Second Clue 3").GetComponent<Text>();
                    thirdClue.text = (string)firstCandidateClues[j];
                    break;
            }
        }
    }

}
