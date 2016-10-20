using UnityEngine;
using System.Collections;

public class ShowAchievements : MonoBehaviour {

    AchievementScript achievementScript;
	// Use this for initialization
	void Start () {
        achievementScript = FindObjectOfType<AchievementScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowAchievementsMenu()
    {
        Debug.Log("I am clicking");
        //Time.timeScale = 1;
        achievementScript.showAchieveMenu();
    }
}
