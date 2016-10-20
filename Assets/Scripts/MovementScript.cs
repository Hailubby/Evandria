using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementScript : MonoBehaviour {

	Rigidbody2D rigidBody;
	Animator anim;
    public string facing = "down";
	public float speed = 4.0f;

    // Used to prevent movement when dialog popup is active
    public bool canMove;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent <Rigidbody2D>();
		anim = GetComponent<Animator> ();
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

        // Prevents the player from moving if interacting with dialog
        if (!canMove)
        {
            return;
        }

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw("Horizontal")*speed,Input.GetAxisRaw("Vertical")*speed);


		if (movement_vector != Vector2.zero) {
			//Only change to walking animation while walking, change facing direction if walking
			anim.SetBool ("iswalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat("input_y",movement_vector.y);

            if (movement_vector.x == 1.0f*speed)
            {
                facing = "right";
            } else if (movement_vector.x == -1.0f*speed)
            {
                facing = "left";
            } else if (movement_vector.y == 1.0f*speed)
            {
                facing = "up";
            } else if (movement_vector.y == -1.0f*speed)
            {
                facing = "down";
            } else
            {
                facing = "error";
                Debug.Log("X is: " + movement_vector.x);
                Debug.Log("Y is: " + movement_vector.y);

            }


		} else {
			//Set to idle animation
			anim.SetBool ("iswalking", false);
		}

		rigidBody.MovePosition (rigidBody.position + movement_vector * Time.deltaTime);

	}

	public void EnableMovement()
    {
        canMove = true;
    }
    
    public void DisableMovement()
    {
        canMove = false;
        anim.SetBool("iswalking", false);
    }
}
