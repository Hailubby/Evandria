using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderboardScript : MonoBehaviour {

    // Use this for initialization

    string[] userArray;
    string[] updatedUserArray;

        
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateUserArray(string user)
    {
        userArray = GetUserArray();

        // convert array to list
        List<string> userList = new List<string>(userArray);
        userList.Add(user);

        //Convert List back to Array to be used in PlayerPrefsX
        updatedUserArray = userList.ToArray();

        // Update the PlayerPrefsX stored.
        PlayerPrefsX.SetStringArray("userArray", updatedUserArray);


    }

    public string[] GetUserArray()
    {
        return PlayerPrefsX.GetStringArray("userArray");
    }
}
