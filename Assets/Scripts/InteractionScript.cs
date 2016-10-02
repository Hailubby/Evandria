using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

    MovementScript move;
    string facing;

	// Use this for initialization
	void Start () {
	    move = GetComponent<MovementScript>();
    }
	
	// Update is called once per frame
	void Update () {
        facing = move.facing;

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Raycast to check for object

            //Call interaction method of object
        }
	}
}
