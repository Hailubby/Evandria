using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {

	GameObject[] objects;
	Vector3[] locations;
	bool[] isPlaced;
	int counter = 0;

	// Use this for initialization
	void Start () {
		objects = new GameObject[2];
		locations = new Vector3[2];
		isPlaced = new bool[2];

		for (int i = 0; i < isPlaced.Length; i++) {
			isPlaced [i] = false;
		}

		System.Random rnd = new System.Random();

		while (counter <= 3) {
			int place = rnd.Next(3);

			if (!isPlaced [place]) {
				// spawn the item
				// put objects[place] in locations[place]
				isPlaced[place] = true;
				counter++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
