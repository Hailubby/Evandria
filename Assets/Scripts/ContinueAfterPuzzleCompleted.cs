using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinueAfterPuzzleCompleted : MonoBehaviour {

    public Button continueButton;

    // Use this for initialization
    //void Start () {
     //   continueButton.gameObject.SetActive(false);
    //}

	public void ShowButton () {
        continueButton.gameObject.SetActive(true);
    }

    public void continueDestroyScene() {
        ItemInteractScript.puzzleDone = true;
        Destroy(GameObject.Find("PuzzleParent"));
    }
}
