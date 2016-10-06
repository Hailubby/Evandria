using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutcomeScript : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public GameObject outcomeCanvas;

    public TextAsset acceptGood;
    public TextAsset acceptBad;
    public TextAsset reject;

    public string outcomeText;
    public int option;

	// Use this for initialization
	void Start () {
        outcomeCanvas.SetActive(false);
        // TO DO: Need to get from Candidate class, which route the candidate went (accept good, accept bad, reject)
        option = 0;

        switch(option)
        {
            case 0:
                outcomeText = acceptGood.text;
                theText.text = outcomeText;
                break;
            case 1:
                outcomeText = acceptBad.text;
                theText.text = outcomeText;
                break;
            case 2:
                outcomeText = reject.text;
                theText.text = outcomeText;
                break;
        }




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
