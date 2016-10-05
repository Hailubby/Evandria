using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Journal which the player will hold throughout the game to store clues found relevant to his investigation.
public class Journal : MonoBehaviour
{

    public MovementScript player;
    public List<Clue> journal;

    // Use this for initialization
    void Start ()
    {
        journal = new List<Clue>();
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
    }
}
