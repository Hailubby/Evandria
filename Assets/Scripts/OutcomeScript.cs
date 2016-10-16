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
        //acceptOption = 0;
        

        //switch (acceptOption)
        //{
        //    case 0:
        //       acceptedText = acceptGood1.text;
        //        theText.text = acceptedText;
        //        break;
        //    case 1:
        //        acceptedText = acceptBad1.text;
        //        theText.text = acceptedText;
        //        break;
        //   case 2:
        //      acceptedText = reject1.text;
        //    theText.text = acceptedText;
        //  break;
        //}





	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PresentOutcome()
    {
        chosenCandidate = FindObjectOfType<EvandriaUpdate>().chosenCandidate;
        outcome = FindObjectOfType<EvandriaUpdate>().goodOutcome;
        string[] chosenFullName = FindObjectOfType<EvandriaUpdate>().chosenCandidateName.Split(' ');
        string chosenName = chosenFullName[0];
        string[] rejectFullName = FindObjectOfType<EvandriaUpdate>().rejectCandidateName.Split(' ');
        string rejectName = rejectFullName[0];
        if (chosenCandidate.Equals("first"))
        {
            if (outcome)
            {
                acceptGood1 = Resources.Load("Outcomes/" + chosenName + "_Good") as TextAsset;
                acceptedText = acceptGood1.text;
                acceptText.text = acceptedText;

                reject2 = Resources.Load("Outcomes/" + rejectName + "_Earth") as TextAsset;
                rejectedText = reject2.text;
                rejectText.text = rejectedText;
            }
            else
            {
                acceptBad1 = Resources.Load("Outcomes/" + chosenName + "_Bad") as TextAsset;
                acceptedText = acceptBad1.text;
                acceptText.text = acceptedText;

                reject2 = Resources.Load("Outcomes/" + rejectName + "_Earth") as TextAsset;
                rejectedText = reject2.text;
                rejectText.text = rejectedText;
            }
        }
        else
        {
            if (outcome)
            {
                acceptGood2 = Resources.Load("Outcomes/" + chosenName + "_Good") as TextAsset;
                acceptedText = acceptGood2.text;
                acceptText.text = acceptedText;

                reject1 = Resources.Load("Outcomes/" + rejectName + "_Earth") as TextAsset;
                rejectedText = reject1.text;
                rejectText.text = rejectedText;
            }
            else
            {
                acceptBad2 = Resources.Load("Outcomes/" + chosenName + "_Bad") as TextAsset;
                acceptedText = acceptBad2.text;
                acceptText.text = acceptedText;

                reject1 = Resources.Load("Outcomes/" + rejectName + "_Earth") as TextAsset;
                rejectedText = reject1.text;
                rejectText.text = rejectedText;
            }
        }
    }
}
