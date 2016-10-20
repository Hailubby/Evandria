using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JournalEntryScript : MonoBehaviour {

    public Text index;
    public Text title;
    public Text candidate;
    public Text description;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Set the index of JournalEntry
    /// </summary>
    /// <param name="index"></param>
    public void SetIndex(string index)
    {
        this.index.text = index;
    }

    /// <summary>
    /// Set the title of JournalEntry
    /// </summary>
    public void SetTitle(string title)
    {
        this.title.text = title;
    }

    /// <summary>
    /// Set the candidate of JournalEntry
    /// </summary>
    /// <param name="candidate"></param>
    public void SetCandidate(string candidate)
    {
        this.candidate.text = candidate;
    }

    /// <summary>
    /// Set the description of the JournalEntry
    /// </summary>
    /// <param name="description"></param>
    public void SetDescription(string description)
    {
        this.description.text = description;
    }
}
