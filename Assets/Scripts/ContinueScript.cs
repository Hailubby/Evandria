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
    public LeaderboardScript leaderboardScript;
    public AchievementScript achievementScript;

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
        continueCanvasScript.currentScore.text = "Your current score is: " + EvandriaUpdate.score.ToString();
        continueCanvasScript.continuePanel.SetActive(true);

        // Show achievement for passing level 1
        if (day == 1)
        {
            achievementScript = FindObjectOfType<AchievementScript>();
            achievementScript.triggerAchievement(AchievementScript.Achievement.DecisionSingle);
        }
       
    }

    // This button script will activate when the player places his final decision on the third/final level
    public void FinalLevelExitScreen()
    {
        message = EvandriaUpdate.score.ToString();

        continueCanvasScript.congratulationsText.text = message;
        continueCanvasScript.congratulationsPanel.SetActive(true);

        // Show achievement for passing final level (level 3)
        if (day == 3)
        {
            achievementScript = FindObjectOfType<AchievementScript>();
            achievementScript.triggerAchievement(AchievementScript.Achievement.DecisionAll);
        }
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

        //Calculate score to display to user
        Debug.Log("current score: " + EvandriaUpdate.score);
        EvandriaUpdate.score += (EvandriaUpdate.level * 10 + HealthBarScript.health);

        //Reseting tic tac toe game variable
        InteractionScript.wonTicTacToe = false;
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
        EvandriaUpdate.level++;
        EvandriaUpdate.score -= HealthBarScript.health;
        Debug.Log("Score before health bar added: " + EvandriaUpdate.score);
        SceneManager.LoadScene(2);
    }

    // Submits score to scoreboard before finishing the entire game
    public void SubmitButton()
    {
        leaderboardScript = FindObjectOfType<LeaderboardScript>();

        user = userInput.text;

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
        // Adds new user
        else
        {
            PlayerPrefs.SetInt(user, EvandriaUpdate.score);
            leaderboardScript.UpdateUserArray(user);
            Reset();
        }
    }

    

    public void GameOverButton()
    {
        Reset();
    }

    // Reset evetryhing back to default values
    public void Reset()
    {
        EvandriaUpdate.level = 1;
        EvandriaUpdate.score = 0;
        HealthBarScript.health = 50;
        int[] temp = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        CandidateLoader.availableCandidates = temp;
        SceneManager.LoadScene(0);
    }
}
