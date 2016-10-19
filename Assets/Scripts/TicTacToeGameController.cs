using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// The Game Controller will set the starting player's side, either "X" or "O", 
// keep track of whose turn it is and when a button is clicked, send the current player's side, 
// check for a winner and either change sides or end the game.
// Reference: https://unity3d.com/learn/tutorials/tic-tac-toe/draw?playlist=17111

public class TicTacToeGameController : MonoBehaviour {

    public Text[] buttonList;
    public Button continueButton;

    private string playerSide;
    private string computerSide;
    public bool playerMove;
    public float delay;
    private int value;

    // Count the number of moves, if moves = 9, its a draw
    private int moveCount;

    // Call this function when the game starts
    void Awake()
    {
        RestartGame();
        SetGameControllerReferenceOnButtons();
        playerMove = true;
        playerSide = "X";
        computerSide = "O";
        moveCount = 0;
        continueButton.gameObject.SetActive(false);
    }

    // Computer's turn to play Tic Tac Toe
    void Update()
    {
        if (playerMove == false)
        { 
        delay += delay * Time.deltaTime;
            if (delay >= 100)
            {
                value = Random.Range(0, 8);
                if (buttonList[value].GetComponentInParent<Button>().interactable == true)
                {
                    buttonList[value].text = "O";
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    // Get the grid space componenets (which are parents of the buttons) and set the TicTacToeGameController reference in the GridSpace component on the parent GameObject.
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
    // Send the playerSide to GridSpace when it calls GetPlayerSide before the buttons set the Text value so the buttons know what symbol to place in their grid space
    public string GetPlayerSide()
    {
        return playerSide;
    }

    // Inform the Game Controller that the turn is now over so that the Game Controller can check the win conditions and either end the game or change the side taking the turn
    public void EndTurn()
    {
        moveCount++;

        // Check to see if the current player has won the game
        // Check the first row
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        // Check the second row
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        // Check the third row
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        // Check the first column
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        // Check the second column
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        // Check the third column
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        // Check the left to right diagonal
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        // Check the right to left diagonal
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].text == computerSide)
        {
            GameOver();
        }

        // Check the second row
        else if (buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].text == computerSide)
        {
            GameOver();
        }

        // Check the third row
        else if (buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver();
        }

        // Check the first column
        else if (buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver();
        }

        // Check the second column
        else if (buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].text == computerSide)
        {
            GameOver();
        }

        // Check the third column
        else if (buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver();
        }

        // Check the left to right diagonal
        else if (buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver();
        }

        // Check the right to left diagonal
        else if (buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver();
        }

        // Checking for ties/draws
        else if (moveCount >= 9)
        {
            GameOver();
        }
        // Checking for ties/draws
        else if (moveCount >= 9)
        {
            GameOver();
        }

        else
        { 
        // Change sides if necessary
        ChangeSides();
        }
    }

    void GameOver()
    {
        SetBoardInteractable(false);
        continueButton.gameObject.SetActive(true);

        //RestartGame();
        // TODO: Quit the scene   
        //QuitScene();
        // reminder: playerSide gets the winner
    }

    // Check what side we are on and change sides
    void ChangeSides()
    {
        //playerSide = (playerSide == "X") ? "O" : "X";
        playerMove = (playerMove == true) ? false : true;
        delay = 10;
    }

    public void QuitScene()
    {
        // TO BE USED IN CONJUNCTION WITH THE FOLLOWING:
        // Time.timeScale = 0; //pauses the current scene 
        // Application.LoadLevelAdditive("YourNextScene"); //loads your desired other scene
        // Time.timeScale = 1; 
        Debug.Log("QUIT SCNEE");
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        //gameOverPanel.SetActive(false);
        playerMove = true;
        delay = 10;

        SetBoardInteractable(true);

        // Iterate through grid spaces and remove the X and O's
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
