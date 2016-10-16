using UnityEngine;
using System.Collections;

public class NPCWalk : MonoBehaviour {

	Rigidbody2D rigidBody;
	Animator anim;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		InvokeRepeating ("Walk", 2.0f, 2.0f);
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
		int x_direction = (int)Mathf.Round (Random.Range (-1, 1));
		int y_direction = (int)Mathf.Round (Random.Range (-1, 1));

		Vector2 movement_vector = new Vector2 (x_direction, y_direction);

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