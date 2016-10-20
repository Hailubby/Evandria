using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JournalPanelScript : MonoBehaviour
{

    // http://www.thegamecontriver.com/2014/10/create-sliding-pause-menu-unity-46-gui.html

    // Reference for the journal panel in the hierarchy
    public GameObject journalPanel;
    // Animator reference
    private Animator anim;
    // Variable for checking if the game is paused 
    private bool isPaused = false;
    
    // Prefab for journal
    public JournalEntryScript journalEntryPrefab;
    // Panels which hold the entries
    public GameObject entriesPanel;

    // To enable/disable his movement
    public MovementScript player;

    // Use this for initialization
    void Start()
    {
        // Resume the game on start
        Time.timeScale = 1;
        // Get the animator component
        anim = journalPanel.GetComponent<Animator>();
        // Disable it on start to stop it from playing the default animation
        anim.enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    // A method invoked to be by the JournalBtn
    public void ToggleJournal()
    {

        // Toggle isPaused 
        // Need to toggle before execution, otherwise toggle doesn't execute, probably because of Time.timeScale
        isPaused = !isPaused;

        // If currently paused
        if (!isPaused)
        {
            HideJournal();
            //Debug.Log("Hiding, isPaused = " + isPaused);
        }
        // If not currently paused
        else
        {
            ShowJournal();
            //Debug.Log("Showing, isPaused = " + isPaused);
        }
    }

    // Method to pause the game and show journal
    private void ShowJournal()
    {
        // Enable the animator component
        anim.enabled = true;
        // Play the Slidein animation
        anim.Play("JournalSlideIn");
        // Freeze the timescale
        Time.timeScale = 0;
        // Disable player movement
        player.canMove = false;
    }

    // Method to resume the game and hide the journal
    private void HideJournal()
    {
        // Set the isPaused flag to false to indicate that the game is not paused
        isPaused = false;
        // Play the SlideOut animation
        anim.Play("JournalSlideOut");
        // Set back the time scale to normal time scale
        Time.timeScale = 1;
        // Enable player movement
        player.canMove = true;
    }

    // Method for (re)populating the journal with player's interactions
    public void UpdateJournal(List<Clue> journal)
    {
        //Debug.Log("Updating Journal");
        EmptyJournal();

        // Count used for index
        int count = 1;
        foreach (Clue clue in journal)
        {
            JournalEntryScript entry = Instantiate<JournalEntryScript>(journalEntryPrefab);
            entry.transform.SetParent(entriesPanel.transform, false);
            entry.SetIndex(count.ToString());
            entry.SetTitle(clue.clueName);
            entry.SetCandidate(clue.clueOwner);
            entry.SetDescription(clue.clueDesc);

            count++;
        }      
    }

    // Method for emptying the journal upon new day (maybe)
    private void EmptyJournal()
    {
        //Debug.Log("Emptying journal panel");
        foreach (Transform child in entriesPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
