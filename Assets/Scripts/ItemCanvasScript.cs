using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Canvas which the item description will popup
public class ItemCanvasScript : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public Image image;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Prints line into textbox for reading
    public void ReadText(string[] textLines, int index)
    {
        theText.text = textLines[index];
    }

    // Enables visibility of Panel, which is the text box
    public void EnablePanel()
    {
        textBox.SetActive(true);
    }

    // Disables visibility of Panel, which is the text box
    public void DisablePanel()
    {
        textBox.SetActive(false);
    }
}
