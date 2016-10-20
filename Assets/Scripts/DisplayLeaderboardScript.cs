using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;

public class DisplayLeaderboardScript : MonoBehaviour {

    public Text[] usernames;
    public Text[] scores;

    public string[] users;

    public PlayerInfo[] playerInfo;

    
    // Use this for initialization
	void Start () {

        // Obtain all the scores 
        users = PlayerPrefsX.GetStringArray("userArray");
        playerInfo = new PlayerInfo[users.Length];

        for (int i = 0; i < users.Length; i++)
        {
            playerInfo[i] = new PlayerInfo();
            playerInfo[i].username = users[i];
            playerInfo[i].score = PlayerPrefs.GetInt(users[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < users.Length && i < 10; i++)
        {
            usernames[i].text = SortArray()[i].username;
            scores[i].text = SortArray()[i].score.ToString();
        }
	}

    public class PlayerInfo
    {
        public string username;
        public int score;
    }

    PlayerInfo[] SortArray()
    {
        playerInfo = playerInfo.OrderBy(x => x.score).ToArray();
        Array.Reverse(playerInfo);
        return playerInfo;
    }
}
