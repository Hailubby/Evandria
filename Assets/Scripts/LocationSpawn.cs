using UnityEngine;
using System.Collections;

public class LocationSpawn : MonoBehaviour {

	GameObject[] objects;
	Vector3[] locations;
	bool[] isPlaced;
	int counter = 0;

	// Use this for initialization
	void Start () {
		objects = new GameObject[3];
		locations = new Vector3[3];
		isPlaced = new bool[3];

		for (int i = 0; i < isPlaced.Length; i++) {
			
		}

		System.Random rnd = new System.Random();

		while (counter != 3) {
			int place = rnd.Next(3);

			if (!isPlaced [place]) {
				// spawn the item
				// put objects[place] in locations[place]
				counter++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
