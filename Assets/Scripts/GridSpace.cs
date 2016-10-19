using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Source: https://unity3d.com/learn/tutorials/tic-tac-toe/foundation-game-play?playlist=17111
public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    // Don't need playerSide anymore, this value is now taken directly from the Game Controller
    // public string playerSide;

    // Hold a reference to our tic tac toe game controller
    private TicTacToeGameController gameController;

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }

    // Takes a GameController as input and assign it to the gameController variable as a reference.
    public void SetGameControllerReference(TicTacToeGameController controller)
    {
        gameController = controller;
    }

}
