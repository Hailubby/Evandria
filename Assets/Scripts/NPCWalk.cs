using UnityEngine;
using System.Collections;

public class NPCWalk : MonoBehaviour {

	Rigidbody2D rigidBody;
	Animator anim;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		InvokeRepeating ("Walk", 2.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {

		//Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		/*
		if (movement_vector != Vector2.zero) {
			anim.SetBool("isWalking", true);
			anim.SetFloat("input_x", movement_vector.x);
			anim.SetFloat("input_y", movement_vector.y);
		} else {
			anim.SetBool("isWalking", false);
		}

		rigidBody.MovePosition(rigidBody.position + movement_vector * Time.deltaTime);
		*/
		}

	void Walk () {
		System.Random rnd = new System.Random ();
		Vector2 movement_vector = new Vector2 (0, 0);

		int direction = rnd.Next (8);

		switch (direction) {
			case 0:
				Debug.Log ("Npc is walking up.");
				movement_vector = new Vector2 (0, 1);
				break;

			case 1:
				Debug.Log ("NPC is walking down.");
				movement_vector = new Vector2 (0, -1);
				break;

			case 2:
				Debug.Log ("NPC is walking left.");
				movement_vector = new Vector2 (-1, 0);
				break;

			case 3:
				Debug.Log ("NPC is walking right.");
				movement_vector = new Vector2 (1, 0);
				break;
			default:
				Debug.Log("NPC is staying still.");
				movement_vector = new Vector2 (0 , 0);
				break;
		}

		if (movement_vector != Vector2.zero) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);
		} else {
			anim.SetBool ("isWalking", false);
		}

		rigidBody.MovePosition (rigidBody.position + movement_vector * Time.deltaTime);
	}
}