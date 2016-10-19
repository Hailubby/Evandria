using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Journal which the player will hold throughout the game to store clues found relevant to his investigation.
public class Journal : MonoBehaviour
{
    AchievementScript achievements;
    public List<Clue> journal;
    bool ClueSingle = false;
    bool ClueCharacter = false;
    bool ClueLevel = false;

    // Use this for initialization
    void Start ()
    {
        journal = new List<Clue>();
        achievements = FindObjectOfType<AchievementScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Adds a clue to the journal
    public void AddClue(Clue clue)
    {
        journal.Add(clue);
        Debug.Log("Added item to journal: " + clue.clueName);
        GameObject.FindObjectOfType<JournalPanelScript>().UpdateJournal(journal);

        //Achievement update
        //Updates on first AddClue
        if (!ClueSingle)
        {
            achievements.triggerAchievement(AchievementScript.Achievement.ClueSingle);
            ClueSingle = true;
        }

        //Checks count of clues from each candidate
        if (!ClueCharacter)
        {
            int count1 = 0, count2 = 0;
            string name1 = "", name2 = "";
            foreach (Clue jclue in journal)
            {
                if (jclue.clueOwner.Equals(name1))
                {
                    count1++;
                } else if (jclue.clueOwner.Equals(name2))
                {
                    count2++;
                }
                else
                {
                    if (name1.Equals(""))
                    {
                        name1 = jclue.clueOwner;
                        count1++;
                    } else if (name2.Equals(""))
                    {
                        name2 = jclue.clueOwner;
                        count2++;
                    } else
                    {
                        Debug.Log("3rd clue owner found in this level");
                        break;
                    }
                }
            }
            if(count1 == 3 || count2 == 3)
            {
                achievements.triggerAchievement(AchievementScript.Achievement.ClueCharacter);
                ClueCharacter = true;
            }
        }

        if (!ClueLevel)
        {
            if(journal.Count >= 6)
            {
                achievements.triggerAchievement(AchievementScript.Achievement.ClueLevel);
                ClueLevel = true;
            }
        }

    }
}
