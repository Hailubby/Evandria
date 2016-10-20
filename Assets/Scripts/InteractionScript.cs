using UnityEngine;
using Assets.Scripts;
using System.Collections;
/**
    Details what a player should do when the E key is pressed and he attempts to interact with an object he is facing
    */
public class InteractionScript : MonoBehaviour {

    public static bool wonTicTacToe = false;

    MovementScript move;
    Rigidbody2D rigidBody;
    string facing;

    public bool interacting;

    public float distance = 20.0f;

	// Use this for initialization
	void Start () {
	    move = GetComponent<MovementScript>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (interacting)
        {
            return;
        }

        facing = move.facing;
        Vector2 direction;

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Determine the direction the character is facing, used for Raycast Direction
            if (facing.Equals("up"))
            {
                direction = Vector2.up;
            }
            else if (facing.Equals("down"))
            {
                direction = Vector2.down;
            }
            else if (facing.Equals("left"))
            {
                direction = Vector2.left;
            }
            else if (facing.Equals("right"))
            {
                direction = Vector2.right;
            }
            else
            {
                Debug.Log("The facing direction is invalid");
                Debug.Log(facing);
                return;
            }

            //Raycast to check for object
            LayerMask mask = LayerMask.GetMask("ItemOrNpc");
            RaycastHit2D hit = Physics2D.Raycast(rigidBody.transform.position, direction,distance,mask.value);
            Debug.DrawRay(rigidBody.transform.position, direction,Color.cyan,2);
            //Call interaction method of object
            if (hit.collider != null)
            {
                Interactable item = hit.collider.gameObject.GetComponent(typeof(Interactable)) as Interactable;
                if (item != null)
                {
                    item.interact();
                }
                else
                {
                    Debug.Log("No interaction script for this collider: " + hit.collider.gameObject.name);
                }

            }
        }
	}

	public void DisableInteracting() {
		interacting = false;
	}
}
