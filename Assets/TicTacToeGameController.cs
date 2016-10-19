using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// The Game Controller will set the starting player's side, either "X" or "O", 
// keep track of whose turn it is and when a button is clicked, send the current player's side, 
// check for a winner and either change sides or end the game.

public class TicTacToeGameController : MonoBehaviour {

    public Text[] buttonList;
    private string playerSide;

    // Call this function when the game starts
    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
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
        // Check to see if the current player has won the game
        // Check the first row
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        // Check the second row
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        // Check the third row
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        // Check the first column
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        // Check the second column
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        // Check the third column
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        // Check the left to right diagonal
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        // Check the right to left diagonal
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }

        // Quit the scene   

    }
}
