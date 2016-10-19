using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// The Game Controller will set the starting player's side, either "X" or "O", 
// keep track of whose turn it is and when a button is clicked, send the current player's side, 
// check for a winner and either change sides or end the game.

public class TicTacToeGameController : MonoBehaviour {

    public Text[] buttonList;
    
    // Call this function when the game starts
    void Awake()
    {
        SetGameControllerReferenceOnButtons();
    }

    // Get the grid space componenets (which are parents of the buttons) and set the TicTacToeGameController reference in the GridSpace component on the parent GameObject.
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
    // Get the Player Side from the Game Controller before the buttons set the Text value so the buttons know what symbol to place in their grid space
    public string GetPlayerSide()
    {
        return "?";
    }

    // Inform the Game Controller that the turn is now over so that the Game Controller can check the win conditions and either end the game or change the side taking the turn
    public void EndTurn()
    {
        Debug.Log("EndTurn is not implemented!");
    }

}
