using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JournalPanelScript : MonoBehaviour
{

    // http://www.thegamecontriver.com/2014/10/create-sliding-pause-menu-unity-46-gui.html

    //refrence for the journal panel in the hierarchy
    public GameObject journalPanel;
    //animator reference
    private Animator anim;
    //variable for checking if the game is paused 
    private bool isPaused = false;
    
    // Prefab for journal
    public GameObject journalPrefab;

    // Use this for initialization
    void Start()
    {
        //unpause the game on start
        Time.timeScale = 1;
        //get the animator component
        anim = journalPanel.GetComponent<Animator>();
        //disable it on start to stop it from playing the default animation
        anim.enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    // A method invoked by the JournalBtn
    public void ToggleJournal()
    {

        // toggle isPaused 
        // need to toggle before execution, otherwise toggle doesn't execute, probably because of Time.timeScale
        isPaused = !isPaused;

        // If currently paused
        if (!isPaused)
        {
            HideJournal();
            Debug.Log("Hiding, isPaused = " + isPaused);
        }
        // If not currently paused
        else
        {
            ShowJournal();
            Debug.Log("Showing, isPaused = " + isPaused);
        }
    }

    //function to pause the game
    private void ShowJournal()
    {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("JournalSlideIn");
        //freeze the timescale
        Time.timeScale = 0;
    }
    //function to unpause the game
    private void HideJournal()
    {
        //set the isPaused flag to false to indicate that the game is not paused
        isPaused = false;
        //play the SlideOut animation
        anim.Play("JournalSlideOut");
        //set back the time scale to normal time scale
        Time.timeScale = 1;
    }

    // Method for (re)populating the journal with player's interactions
    private void UpdateJournal(List<Clue> journal)
    {
        Debug.Log("Updating Journal -- untested");
        GameObject entry = Instantiate(journalPrefab);
        entry.transform.SetParent(GameObject.Find("JournalPanel").transform,false);
    }

    // Method for emptying the journal upon new day (maybe)
    private void EmptyJournal()
    {
        Debug.Log("Emptying journal panel -- untested");
        foreach (Transform child in journalPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
