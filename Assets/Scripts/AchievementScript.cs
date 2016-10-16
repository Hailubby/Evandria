using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementScript : MonoBehaviour {

    /*
     * Achievement 1: Find first clue
     * Achievement 2: Find three clues for one character
     * Achievement 3: Find six clues for a level
     * Achievement 4: Make first decision
     * Achievement 5: Made three decisions [Complete game]
     * Achievement 6: Ran out of time on a level
     * 
     * */
    public enum Achievement {ClueSingle,ClueCharacter,ClueLevel,DecisionSingle,DecisionAll,OutOfTime};

    public GameObject achievementPopup;
    public GameObject popupPanel;
    public GameObject achievementText;
    public GameObject achievementMenu;
    public GameObject achievementImage;
    public CanvasGroup popupGroup;

    public GameObject[] achievements;

    //Achievement booleans
    bool achieve1 = false;
    bool achieve2 = false;
    bool achieve3 = false;
    bool achieve4 = false;
    bool achieve5 = false;
    bool achieve6 = false;

    //Achievement Icons
    public Sprite icon1;
    public Sprite icon2;
    public Sprite icon3;
    public Sprite icon4;
    public Sprite icon5;
    public Sprite icon6;
    

    float executionTime = 0f;
    public float popupTime = 2.0f;

	// Use this for initialization
	void Start () {
        //Find the popup canvas
        achievementPopup = GameObject.Find("AchievePopup");
        popupGroup = achievementPopup.GetComponent<CanvasGroup>();
        //Find the achievements
        achievements = GameObject.FindGameObjectsWithTag("Achievement");


        achievementPopup.SetActive(false);
        achievementMenu.SetActive(false);

        
	}
	
	// Update is called once per frame
	void Update () {

        //Only called if Num 1-6 are to be used to test the achievement unlock popups
        testAchievements();

        //If popup is being displayed, after specified popupTime close the popup
        if (executionTime != 0f)
        {
            if (Time.time > executionTime + popupTime)
            {
                executionTime = 0f;
                achievementPopup.SetActive(false);
            }
        }
	}

    //Used to trigger the popup for an achievement if it hasn't been earned yet
    void triggerAchievement(Achievement achievement)
    {
        switch (achievement)
        {
            case Achievement.ClueSingle:
                if (!achieve1)
                {
                    achieve1 = true;
                    showPopup("Just the beginning",icon1);
                }
                break;
            case Achievement.ClueCharacter:
                if (!achieve2)
                {
                    achieve2 = true;
                    showPopup("I've got my eye on you", icon2);
                }
                break;
            case Achievement.ClueLevel:
                if (!achieve3)
                {
                    achieve3 = true;
                    showPopup("Thorough Investigation", icon3);
                }
                break;
            case Achievement.DecisionSingle:
                if (!achieve4)
                {
                    achieve4 = true;
                    showPopup("Difficult Choice", icon4);
                }
                break;
            case Achievement.DecisionAll:
                if (!achieve5)
                {
                    achieve5 = true;
                    showPopup("Making a Difference", icon5);
                }
                break;
            case Achievement.OutOfTime:
                if (!achieve6)
                {
                    achieve6 = true;
                    showPopup("Out of Time", icon6);
                }
                break;
        }
    }

    //Displays the achievement popup with the specified achievement name
    void showPopup(string achievementName, Sprite sprite)
    {
        Debug.Log("An Achievement is shown");

        //Keep track of time popup was shown initially
        executionTime = Time.time;
        //Assign text and set to visible
        achievementText.GetComponent<Text>().text = achievementName;
        achievementImage.GetComponent<Image>().sprite = sprite; 
        achievementPopup.SetActive(true);
        popupGroup.alpha = 0;

        StartCoroutine(fadePopupCoroutine());
    }

   private IEnumerator fadePopupCoroutine()
    {
        while (popupGroup.alpha < 1)
        {
            popupGroup.alpha += Time.deltaTime * 1f;
            yield return null;
        }
    }

    //Method only used for testing
    void testAchievements()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            showPopup("Niiiiiiceeeeee", icon5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            triggerAchievement(Achievement.ClueSingle);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            triggerAchievement(Achievement.ClueCharacter);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            triggerAchievement(Achievement.ClueLevel);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            triggerAchievement(Achievement.DecisionSingle);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            triggerAchievement(Achievement.DecisionAll);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            triggerAchievement(Achievement.OutOfTime);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            
            showAchieveMenu();
        }
    }

    //Presents the menu, toggles visibility, if visible load in updates to achievements
    void showAchieveMenu()
    {
        achievementMenu.SetActive(!achievementMenu.activeSelf);

        if (achievementMenu.activeSelf == true)
        {
            
            //Populate the achievement menu
            //If achievement is earned
            if (achieve1)
            {
                GameObject achievement = achievements[5];
                var text = achievement.GetComponentsInChildren<Text>();
                foreach (var textobj in text)
                {
                    if (textobj.text.Equals("To be discovered"))
                    {
                        textobj.text = "Find your first clue";
                    }
                }

                var img = achievement.GetComponentsInChildren<Image>()[1];
                img.sprite = icon1;
            } 
            if (achieve2)
            {
                GameObject achievement = achievements[4];
                var text = achievement.GetComponentsInChildren<Text>();
                foreach (var textobj in text)
                {
                    if (textobj.text.Equals("To be discovered"))
                    {
                        textobj.text = "Find all clues relating to a single candidate";
                    }
                }

                var img = achievement.GetComponentsInChildren<Image>()[1];
                img.sprite = icon2;
            } 
            if (achieve3)
            {
                GameObject achievement = achievements[3];
                var text = achievement.GetComponentsInChildren<Text>();
                foreach (var textobj in text)
                {
                    if (textobj.text.Equals("To be discovered"))
                    {
                        textobj.text = "Find all clues for the current level";
                    }
                }

                var img = achievement.GetComponentsInChildren<Image>()[1];
                img.sprite = icon3;
            }
            if (achieve4)
            {
                GameObject achievement = achievements[2];
                var text = achievement.GetComponentsInChildren<Text>();
                foreach (var textobj in text)
                {
                    if (textobj.text.Equals("To be discovered"))
                    {
                        textobj.text = "Make your first decision";
                    }
                }

                var img = achievement.GetComponentsInChildren<Image>()[1];
                img.sprite = icon4;
            }
            if (achieve5)
            {
                GameObject achievement = achievements[1];
                var text = achievement.GetComponentsInChildren<Text>();
                foreach (var textobj in text)
                {
                    if (textobj.text.Equals("To be discovered"))
                    {
                        textobj.text = "Make three consecutive decisions";
                    }
                }

                var img = achievement.GetComponentsInChildren<Image>()[1];
                img.sprite = icon5;
            }
            if (achieve6)
            {
                GameObject achievement = achievements[0];
                var text = achievement.GetComponentsInChildren<Text>();
                foreach (var textobj in text)
                {
                    if (textobj.text.Equals("To be discovered"))
                    {
                        textobj.text = "Run out of time in your day";
                    }
                }

                var img = achievement.GetComponentsInChildren<Image>()[1];
                img.sprite = icon6;
            }


        }
    }
}
