using UnityEngine;
using System.Collections;

public class SettingsCanvasScript : MonoBehaviour {

    public MovementScript player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Method to open settings
    /// </summary>
    public void OpenSettings()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
        player.canMove = false;
    }

    /// <summary>
    /// Method to close the settings
    /// </summary>
    public void CloseSettings()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        player.canMove = true;
    }
}
