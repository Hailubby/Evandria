using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {

	//GameObject[] objects;
	GameObject currentObject;
	Vector3[] locations;
	bool[] isPlaced;
	int counter = 0;

	// Use this for initialization
	void Start () {
		//objects = new GameObject[2];
		locations = new Vector3[4];
		isPlaced = new bool[4];
		currentObject = GameObject.Find ("Axe");

		for (int i = 0; i < isPlaced.Length; i++) {
			if (i == 2) {
				isPlaced [i] = false;
			} else {
				isPlaced [i] = true;
			}
		}

		locations [0] = new Vector3 (5, 0, 0);
		locations [1] = new Vector3 (-5, 0, 0);
		locations [2] = new Vector3 (0, 5, 0);
		locations [3] = new Vector3 (0, -5, 0);

		System.Random rnd = new System.Random();

		while (counter < 1) {
			int place = rnd.Next(4);

			if (!isPlaced [place]) {
				currentObject.transform.position = locations [place];
				isPlaced [place] = true;
				counter++;
			} else {
				Debug.Log ("Currently isPlaced[place] = true and place = " + place);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
