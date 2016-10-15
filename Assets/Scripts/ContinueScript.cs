using UnityEngine;
using System.Collections;

public class ContinueScript : MonoBehaviour {

    public int day;
    public int impact;
    public GameObject outcomeCanvas;
    public GameObject continueCanvas;
    public ContinueGameOverCanvasScript continueCanvasScript;
    public EvandriaUpdate update;

    private string posMessage;
    private string negMessage;
    private string message;

	// This button script will activate if there are more levels to be played, and the player has not reached game over
    public void ContinueToNextLevel()
    {
        // if negative impact, then bad message
        // if positive impact, then good message
        posMessage = "Your actions have positively influenced Evandria!";
        negMessage = "Your actions have negatively influenced Evandria.";

        // Determines what message the player will see depending on the influence of the candidate on Evandria
        if (impact >= 0)
        {
            message = posMessage;
        }
        else
        {
            message = negMessage;
        }

        continueCanvasScript.continueText.text = message;
        continueCanvasScript.continuePanel.SetActive(true);
    }

    // This button script will activate when the player places his final decision on the third/final level
    public void FinalLevelExitScreen()
    {
        message = "SCORE GOES HERE";

        continueCanvasScript.congratulationsText.text = message;
        continueCanvasScript.congratulationsPanel.SetActive(true);
    }

    // This button script will activate when continue is clicked, if the player has killed Evandria with his selections
    public void GameOver()
    {
        continueCanvasScript.gameOverPanel.SetActive(true);
    }
    
    // Detremines which screen to show upon mkaing a decision
    public void DetermineContinue()
    {
        // Brings up the continue screen
        continueCanvas.SetActive(true);
        continueCanvasScript = FindObjectOfType<ContinueGameOverCanvasScript>();

        // Disbales all panels in case of any leftover from previous screens
        continueCanvasScript.continuePanel.SetActive(false);
        continueCanvasScript.congratulationsPanel.SetActive(false);
        continueCanvasScript.gameOverPanel.SetActive(false);

        // Finds out important values based on the decision made
        update = FindObjectOfType<EvandriaUpdate>();
        impact = update.changeInMorale;
        day = update.day;
        
        // Close Outcome Canvas
        outcomeCanvas.SetActive(false);


        // If players decision reached a game over
        if (day == -1)
        {
            GameOver();
        }
        // If this is the last day
        else if (day == 3)
        {
            FinalLevelExitScreen();
        }
        else
        {
            ContinueToNextLevel();
        }
    }

    public void ContinueButton()
    {
        //TODO continue to next level
    }

    public void CongratulationsButton()
    {
        // TODO enter deets for highscore stuffs
    }

    public void GameOverButton()
    {
        // TODO take back to main menu/restart game?
    }
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
