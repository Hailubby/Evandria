using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour {

    public InputField enterUser;
    public Text result;

    public string username;

    public void FindHighScore()
    {
        username = enterUser.text;
        Debug.Log(username);
        // Username specified is inside database
        if (PlayerPrefs.HasKey(username))
        {
            result.text = username + ": " + PlayerPrefs.GetInt(username);

        }
        // Username specified is not in database
        else
        {
            // Inform user that it is not valid
            result.text = "No score recorded for: " + username;
        }
        


    }
}
