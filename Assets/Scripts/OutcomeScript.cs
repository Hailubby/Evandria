using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutcomeScript : MonoBehaviour {

    public string chosenCandidate;
    public bool outcome;
    public Text acceptText;
    public Text rejectText;

    public TextAsset acceptGood1;
    public TextAsset acceptBad1;
    public TextAsset reject1;
    public TextAsset acceptGood2;
    public TextAsset acceptBad2;
    public TextAsset reject2;

    public string acceptedText;
    public string rejectedText;

    public int acceptOption;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PresentOutcome()
    {
        chosenCandidate = FindObjectOfType<EvandriaUpdate>().chosenCandidate;
        outcome = FindObjectOfType<EvandriaUpdate>().goodOutcome;
        Debug.Log(chosenCandidate);
        if (chosenCandidate.Equals("Gabriel Johan"))
        {
            if (outcome)
            {
                acceptedText = acceptGood1.text;
                acceptText.text = acceptedText;

                rejectedText = reject2.text;
                rejectText.text = rejectedText;
            }
            else
            {
                acceptedText = acceptBad1.text;
                acceptText.text = acceptedText;

                rejectedText = reject2.text;
                rejectText.text = rejectedText;
            }
        }
        else
        {
            if (outcome)
            {
                acceptedText = acceptGood2.text;
                acceptText.text = acceptedText;

                rejectedText = reject1.text;
                rejectText.text = rejectedText;
            }
            else
            {
                acceptedText = acceptBad2.text;
                acceptText.text = acceptedText;

                rejectedText = reject1.text;
                rejectText.text = rejectedText;
            }
        }
    }
}
