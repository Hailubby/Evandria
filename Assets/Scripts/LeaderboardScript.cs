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

        Debug.Log("Before");

        foreach (var item in userArray)
        {
            Debug.Log(item);
        }

        // convert array to list
        List<string> userList = new List<string>(userArray);
        userList.Add(user);

        //Convert List back to Array to be used in PlayerPrefsX
        updatedUserArray = userList.ToArray();

        Debug.Log("After");
        foreach (var item in updatedUserArray)
        {
            Debug.Log(item);
        }

        // Update the PlayerPrefsX stored.
        PlayerPrefsX.SetStringArray("userArray", updatedUserArray);

    }

    public string[] GetUserArray()
    {
        return PlayerPrefsX.GetStringArray("userArray");
    }
}
