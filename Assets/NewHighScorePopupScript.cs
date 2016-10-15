using UnityEngine;
using System.Collections;

public class NewHighScorePopupScript : MonoBehaviour {

    public GameObject newHighScorePanel;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            // TODO return to main menu
            newHighScorePanel.SetActive(false);
        }
	}
}
