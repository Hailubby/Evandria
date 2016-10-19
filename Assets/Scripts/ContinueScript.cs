using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour {

    public int day;
    public int impact;
    public GameObject outcomeCanvas;
    public GameObject continueCanvas;
    public GameObject newHighscorePanel;
    public ContinueGameOverCanvasScript continueCanvasScript;
    public EvandriaUpdate update;

    private string posMessage;
    private string negMessage;
    private string message;
    public InputField userInput;
    //public int score;
    public string user;

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
    
    // Detremines which screen to show upon making a decision upon button click on OutcomeCanvas
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
        day = EvandriaUpdate.level;
        
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

    // Continues to next level
    public void ContinueButton()
    {
        //TODO continue to next level
        Debug.Log("Current score: " + EvandriaUpdate.score + " | level bonus: " + EvandriaUpdate.level * 10);
        EvandriaUpdate.score += EvandriaUpdate.level * 10;
        Debug.Log("Updated score: " + EvandriaUpdate.score);
        EvandriaUpdate.level++;
        SceneManager.LoadScene(2);
    }

    // Submits score to scoreboard before finishing the entire game
    public void ContinueSubmitButton()
    {
        user = userInput.text;
        EvandriaUpdate.score += EvandriaUpdate.level * 10;
        Debug.Log("Score: " + EvandriaUpdate.score);

        // Checks if user exists in current database of scores
        if (PlayerPrefs.HasKey(user))
        {
            // Checks if it beat the current score of specified user
            if (PlayerPrefs.GetInt(user) < EvandriaUpdate.score)
            {
                // Updates specified user's score
                PlayerPrefs.SetInt(user, EvandriaUpdate.score);
                newHighscorePanel.SetActive(true);
            }
            else
            {
                Reset();
            }
        }
        else
        {
            PlayerPrefs.SetInt(user, EvandriaUpdate.score);
            Reset();
        }
    }

    public void CongratulationsButton()
    {
        // TODO enter deets for highscore stuffs
        user = userInput.text;
        EvandriaUpdate.score += EvandriaUpdate.level * 10;

        // Checks if user exists in current database of scores
        if (PlayerPrefs.HasKey(user))
        {
            // Checks if it beat the current score of specified user
            if (PlayerPrefs.GetInt(user) < EvandriaUpdate.score)
            {
                // Updates specified user's score
                PlayerPrefs.SetInt(user, EvandriaUpdate.score);
                newHighscorePanel.SetActive(true);
            }
            else
            {
                Reset();
            }
        }
        else
        {
            PlayerPrefs.SetInt(user, EvandriaUpdate.score);
            Reset();
        }
        
    }

    public void GameOverButton()
    {
        // TODO take back to main menu/restart game?
        Reset();
    }
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Reset evetryhing back to start
    public void Reset()
    {
        EvandriaUpdate.level = 1;
        EvandriaUpdate.score = 0;
        HealthBarScript.health = 50;
        //EvandriaUpdate.netImpact = 0;
        int[] temp = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        CandidateLoader.availableCandidates = temp; 
        SceneManager.LoadScene(0);
    }
}
