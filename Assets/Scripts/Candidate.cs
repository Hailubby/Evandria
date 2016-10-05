using UnityEngine;
using System.Collections;

public class Candidate : MonoBehaviour {

	// unique identifier
	private int id;

    private string fullname;
    private string gender;
    private string birthdate;
    private string ethnicity;
    private string[] traits;
    private string occupation;
    private string[] skills;
    private string description;

    // list of clues
    private Clue[] clues;

    // Use this for initialization
    void Start () {
         getData();
    }
	
	// Update is called once per frame
	void Update () {
	}

	// somehow get data from xml/txt files
	void getData() {
		
	}
}
