using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewHighScorePopupScript : MonoBehaviour {

    ContinueScript script;

    public GameObject newHighScorePanel;
    // Use this for initialization
	void Start () {
        script = FindObjectOfType<ContinueScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            // TODO return to main menu
            newHighScorePanel.SetActive(false);
            script.Reset();
        }
	}
}
